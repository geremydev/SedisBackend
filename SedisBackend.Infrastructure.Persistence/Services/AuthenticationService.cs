using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Application.Helpers;
using SedisBackend.Core.Domain.DTO.Error;
using SedisBackend.Core.Domain.DTO.Identity.Authentication;
using SedisBackend.Core.Domain.DTO.Shared;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Enums;
using SedisBackend.Core.Domain.Interfaces.Services.Identity;
using SedisBackend.Core.Domain.Interfaces.Services.Shared;
using System.Text;

namespace SedisBackend.Infrastructure.Persistence.Services;

public class AuthenticationService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly SignInManager<User> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly IEmailService _emailServices;
    private readonly ICardValidationService _cardValidationService;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;

    private readonly ISender _sender;

    public AuthenticationService(UserManager<User> userManager,
        SignInManager<User> signInManager, ISender sender, IEmailService emailServices,
        IMapper mapper, ITokenService tokenService,
        ICardValidationService cardValidationService, RoleManager<IdentityRole<Guid>> roleManager)
    {
        _sender = sender;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _userManager = userManager;
        _emailServices = emailServices;
        _tokenService = tokenService;
        _mapper = mapper;
        _cardValidationService = cardValidationService;
    }

    public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.CardId == request.CardId);

        if (user == null || !(await _signInManager.CheckPasswordSignInAsync(user, request.Password, false)).Succeeded)
        {
            return new AuthenticationResponse
            {
                Succeeded = true,
                Error = "Invalid identification number or password."
            };
        }

        var token = await _tokenService.CreateToken(user);
        var refreshToken = _tokenService.GenerateRefreshToken().Token;

        return new AuthenticationResponse
        {
            Id = user.Id,
            Email = user.Email,
            UserName = user.UserName,
            Roles = (await _userManager.GetRolesAsync(user)).ToList(),
            Succeeded = false,
            JWToken = token,
            RefreshToken = refreshToken
        };
    }

    public async Task<string> RefreshTokenAsync(string token, string refreshToken)
    {
        return await _tokenService.RefreshTokenAsync(token, refreshToken);
    }

    public async Task SingOutAsync()
    {
        await _signInManager.SignOutAsync();
    }


    //GETBYID
    public async Task<ServiceResult> RegisterUserAsync(RegisterRequest request, string origin, RolesEnum userRole)
    {
        ServiceResult response = new ServiceResult();

        // Validate the CardId
        var cardValidation = await _cardValidationService.VerifyCardId(request.CardId);
        if (!cardValidation.Valid)
        {
            response.Errors.Add(new CustomError { Code = "REG01", Description = "Invalid CardId." });
            return response;
        }

        var userWithSameCardId = await _userManager.Users.FirstOrDefaultAsync(u => u.CardId == request.CardId);
        if (userWithSameCardId != null)
        {
            response.Errors.Add(new CustomError { Code = "REG02", Description = $"Identification number {request.CardId} is already registered." });
            return response;
        }

        // Check if email already exists
        var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
        if (userWithSameEmail != null)
        {
            response.Errors.Add(new CustomError { Code = "REG03", Description = $"Email {request.Email} is already registered." });
            return response;
        }

        // Create the new user
        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            CardId = request.CardId,
            Birthdate = request.Birthdate,
            Sex = request.Sex,
            ImageUrl = request.ImageUrl,
            UserName = request.UserName,
            EmailConfirmed = false,
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnabled = false,
            SecurityStamp = Guid.NewGuid().ToString(),
            Email = request.Email,
            IsActive = request.IsActive,
            PhoneNumber = request.PhoneNumber,
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            response.Errors.Add(new CustomError { Code = "REG04", Description = "An error occurred trying to register the user." });
            return response;
        }

        // Assign role to the user
        if (await _roleManager.RoleExistsAsync(userRole.ToString()))
        {
            var roleResult = await _userManager.AddToRoleAsync(user, userRole.ToString());
            if (!roleResult.Succeeded)
            {
                response.Errors.Add(new CustomError { Code = "REG05", Description = $"Failed to assign role '{userRole.ToString()}' to user." });
                return response;
            }
        }
        else
        {
            response.Errors.Add(new CustomError { Code = "REG06", Description = $"Role '{userRole.ToString()}' does not exist." });
            return response;
        }

        // Send email verification
        var verificationURI = await SendVerificationUri(user, origin);
        await _emailServices.SendAsync(new EmailRequest
        {
            To = user.Email,
            Body = $"Please confirm your account by visiting this URL: {verificationURI}",
            Subject = "Confirm registration"
        });

        response.Succeeded = true;
        return response;
    }

    public async Task<string> ConfirmAccountAsync(string userId, string token)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return $"No user register under this {user.Email} account";
        }

        token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
        var result = await _userManager.ConfirmEmailAsync(user, token);
        if (result.Succeeded)
        {
            return $"Account confirm for {user.Email} you can now use the app";
        }
        else
        {
            return $"An error occurred wgile confirming {user.Email}.";
        }
    }

    public async Task<ServiceResult> ForgotPassswordAsync(ForgotPasswordRequest request, string origin)
    {
        ServiceResult response = new();

        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
        {
            response.Errors.Add(new CustomError { Code = "FPS01", Description = $"No accounts registered with {request.Email}" });
            return response;
        }

        var verificationURI = await SendForgotPasswordUri(user, origin);

        await _emailServices.SendAsync(new EmailRequest()
        {
            To = user.Email,
            Body = $"Please reset your account visiting this URL {verificationURI}",
            Subject = "reset password"
        });

        return response;
    }

    public async Task<ServiceResult> ResetPasswordAsync(ResetPasswordRequest request)
    {
        ServiceResult response = new();

        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
        {
            response.Errors.Add(new CustomError { Code = "RPS01", Description = $"No accounts registered with {request.Email}" });
            return response;
        }

        request.Token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Token));
        var result = await _userManager.ResetPasswordAsync(user, request.Token, request.Password);

        if (!result.Succeeded)
        {
            response.Errors.Add(new CustomError { Code = "RPS02", Description = $"An error occurred while reset password" });
            return response;
        }

        response.Succeeded = true;
        return response;
    }

    public async Task<DtoAccount> GetByCardIdAsync(string UserCardId)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.CardId == UserCardId);
        DtoAccount dtoaccount = new()
        {
            Email = user.Email,
            Id = user.Id,
            UserName = user.UserName,
            ImageUrl = user.ImageUrl,
            IsActive = user.IsActive,
            PhoneNumber = user.PhoneNumber,
            Password = user.PasswordHash
        };
        return dtoaccount;
    }

    public async Task<DtoAccount> GetByIdAsync(string UserId)
    {
        var user = await _userManager.FindByIdAsync(UserId);
        DtoAccount dtoaccount = new()
        {
            Email = user.Email,
            Id = user.Id,
            UserName = user.UserName,
            ImageUrl = user.ImageUrl,
            IsActive = user.IsActive,
            PhoneNumber = user.PhoneNumber,
            Password = user.PasswordHash
        };
        return dtoaccount;
    }

    //GETBYID
    public async Task<DtoAccount> GetByEmail(string Email)
    {
        var user = await _userManager.FindByEmailAsync(Email);
        DtoAccount dtoaccount = new()
        {
            Email = user.Email,
            Id = user.Id,
            UserName = user.UserName,
            ImageUrl = user.ImageUrl,
            IsActive = user.IsActive,
            PhoneNumber = user.PhoneNumber,
        };
        return dtoaccount;
    }


    //DELETE USER
    public async Task Remove(DtoAccount account)
    {
        ServiceResult response = new();

        var user = await _userManager.FindByIdAsync(account.Id.ToString());
        if (user == null)
        {
            response.Errors.Add(new CustomError { Code = "RMV01", Description = $"This user does not exist now" });
        }

        response.Succeeded = true;
        await _userManager.DeleteAsync(user);
    }

    //USERS GETALL
    public async Task<List<DtoAccount>> GetAllUsers()
    {
        var userList = await _userManager.Users.ToListAsync();
        List<DtoAccount> DtoUserList = new();
        foreach (var user in userList)
        {
            var userDto = new DtoAccount();

            userDto.ImageUrl = user.ImageUrl;
            userDto.IsActive = user.IsActive;
            userDto.Email = user.Email;
            userDto.Id = user.Id;
            userDto.Roles = _userManager.GetRolesAsync(user).Result.ToList();
            DtoUserList.Add(userDto);
        }
        return DtoUserList;
    }

    //USER AUTHENTICATION

    //CHANGE USER STATUS
    public async Task<ServiceResult> ChangeUserStatus(RegisterRequest request)
    {
        ServiceResult response = new();

        var userget = await _userManager.FindByEmailAsync(request.Email.ToString());
        {
            userget.IsActive = request.IsActive;
        }
        var result = await _userManager.UpdateAsync(userget);

        if (!result.Succeeded)
        {
            response.Errors.Add(new CustomError { Code = "CUS01", Description = $"There was an error while trying to update the user{userget.UserName}" });
        }

        response.Succeeded = true;
        return response;
    }

    //EDITUSER
    public async Task<ServiceResult> UpdateUserAsync(RegisterRequest request)
    {
        ServiceResult response = new();
        var userget = await _userManager.FindByEmailAsync(request.Email.ToString());
        {
            userget.PhoneNumber = request.PhoneNumber;
            userget.UserName = request.UserName;
            userget.Email = request.Email;
            userget.ImageUrl = request.ImageUrl;
        }
        if (request.Password != null)
        {
            var Token = await _userManager.GeneratePasswordResetTokenAsync(userget);
            await _userManager.ResetPasswordAsync(userget, Token, request.Password);
        }
        if (request.ImageUrl != null)
        {
            userget.ImageUrl = UploadImage.UploadFile(request.FormFile, request.CardId, "User", true, request.ImageUrl);
        }
        else
        {
            userget.ImageUrl = UploadImage.UploadFile(request.FormFile, request.CardId, "User", false, userget.ImageUrl);
        }
        var result = await _userManager.UpdateAsync(userget);
        if (!result.Succeeded)
        {
            response.Errors.Add(new CustomError { Description = "There was an error while trying to update the user{userget.UserName}" });
        }

        response.Succeeded = true;
        return response;
    }


    //REGISTER USER



    //CONFIRMACCOUNT

    //FORGOTPASSWORD


    //RESETPASSWORD

    //SINGOUT

    #region PrivateMethods

    //SENDFORGOTPASSWORDURI
    private async Task<string> SendForgotPasswordUri(User user, string origin)
    {
        var code = await _userManager.GeneratePasswordResetTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        var route = "User/ResetPassword";
        var Uri = new Uri(string.Concat($"{origin}/", route));
        var verificationUri = QueryHelpers.AddQueryString(Uri.ToString(), "Token", code);

        return verificationUri;
    }

    //SEMDVERIFICATIONURI
    private async Task<string> SendVerificationUri(User user, string origin)
    {
        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        var route = "api/account/confirm-email";
        var Uri = new Uri(string.Concat($"{origin}/", route));
        var verificationUri = QueryHelpers.AddQueryString(Uri.ToString(), "userId", user.Id.ToString());
        verificationUri = QueryHelpers.AddQueryString(verificationUri, "Token", code);

        return verificationUri;
    }

    public Task<ServiceResult> AddRole(string CardId, Guid HealthCenterId, RolesEnum Role)
    {
        throw new NotImplementedException();
    }

    #endregion
    public async Task<ServiceResult> AddRole(string idCard, Guid healthCenterId, string role)
    {
        ServiceResult response = new();

        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.CardId == idCard);

        if (user == null)
        {
            response.Errors.Add(new CustomError { Code = "ADR01", Description = "User with specified CardId not found." });
            return response;
        }

        if (!await _roleManager.RoleExistsAsync(role))
        {
            response.Errors.Add(new CustomError { Code = "ADR02", Description = $"Role '{role}' does not exist." });
            return response;
        }

        if (!await _userManager.IsInRoleAsync(user, role))
        {
            var roleResult = await _userManager.AddToRoleAsync(user, role);

            if (!roleResult.Succeeded)
            {
                response.Errors.Add(new CustomError { Code = "ADR03", Description = $"Failed to assign role '{role}' to the user." });
                return response;
            }
        }
        else
        {
            response.Errors.Add(new CustomError { Code = "ADR04", Description = $"Role '{role}' is already assigned to the user." });
            return response;
        }

        response.Succeeded = true;
        return response;
    }

}
