using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Application.Dtos.Account;
using SedisBackend.Core.Application.Dtos.Email;
using SedisBackend.Core.Application.Dtos.Error;
using SedisBackend.Core.Application.Helpers;
using SedisBackend.Core.Application.Interfaces.Services;
using SedisBackend.Infrastructure.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Infrastructure.Identity.Services
{
    public class AccountServices: IAccountServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailServices _emailServices;

        public AccountServices(UserManager<ApplicationUser> userManager,
                             SignInManager<ApplicationUser> signInManager,
                             IEmailServices emailServices)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailServices = emailServices;
        }

        //GETBYID
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

            var user = await _userManager.FindByIdAsync(account.Id);
            if (user == null)
            {
                response.HasError = true;
                response.Error = $"This user does not exist now";
            }
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
        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            AuthenticationResponse response = new();

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                response.HasError = true;
                response.Error = $"No accounts registered under Email {request.Email}";
                return response;
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                response.HasError = true;
                response.Error = $"Invalid Credential for {request.Email}";
                return response;
            }
            if (!user.EmailConfirmed)
            {
                response.HasError = true;
                response.Error = $"Account not confirmed for {request.Email}";
                return response;
            }
            if (user.IsActive == false)
            {
                response.HasError = true;
                response.Error = $"Your account user {request.Email} is not active please get in contact with a manager";
                return response;
            }

            response.Id = user.Id;
            response.Email = user.Email;
            response.UserName = user.UserName;

            var roleList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);

            response.Roles = roleList.ToList();
            response.IsVerified = user.EmailConfirmed;
            response.ImageUrl = user.ImageUrl;

            return response;
        }

        //CHANGE USER STATUS
        public async Task<ServiceResult> ChangeUserStatus(RegisterRequest request)
        {
            ServiceResult response = new();
            var userget = await _userManager.FindByIdAsync(request.Id);
            {
                userget.IsActive = request.IsActive;
            }
            var result = await _userManager.UpdateAsync(userget);
            if (!result.Succeeded)
            {
                response.HasError = true;
                response.Error = $"There was an error while trying to update the user{userget.UserName}";
            }
            return response;
        }

        //EDITUSER
        public async Task<ServiceResult> UpdateUserAsync(RegisterRequest request)
        {
            ServiceResult response = new();
            var userget = await _userManager.FindByIdAsync(request.Id);
            {
                userget.Id = request.Id;
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
                userget.ImageUrl = UploadImage.UploadFile(request.FormFile, request.Id, "User", true, request.ImageUrl);
            }
            else
            {
                userget.ImageUrl = UploadImage.UploadFile(request.FormFile, request.Id, "User", false, userget.ImageUrl);
            }
            var result = await _userManager.UpdateAsync(userget);
            if (!result.Succeeded)
            {
                response.HasError = true;
                response.Error = $"There was an error while trying to update the user{userget.UserName}";
            }
            return response;
        }


        //REGISTER USER

        public async Task<ServiceResult> RegisterUserAsync(RegisterRequest request, string origin, string UserRoles)
        {
            ServiceResult response = new()
            {
                HasError = true,
            };

            var userWithSameUserName = await _userManager.FindByNameAsync(request.UserName);
            if (userWithSameUserName != null)
            {
                response.HasError = true;
                response.Error = $"Username {request.UserName} is already taken";
                return response;
            }

            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
            if (userWithSameEmail != null)
            {
                response.HasError = true;
                response.Error = $"Email {request.Email} is already registered";
                return response;
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.UserName,
                IsActive = request.IsActive,
                ImageUrl = request.ImageUrl,
                PhoneNumber = request.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, UserRoles);
                var verificationURI = await SendVerificationUri(user, origin);
                await _emailServices.SendAsync(new EmailRequest()
                {
                    To = user.Email,
                    Body = $"Please confirm your account visiting this URL {verificationURI}",
                    Subject = "Confirm registration"
                });
            }
            else
            {
                response.HasError = true;
                response.Error = $"An error occurred trying to register the user.";
                return response;
            }

            response.Error = "Favor confirmar la cuenta.";
            return response;
        }


        //CONFIRMACCOUNT
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
                return $"Account confirm for {user.Email} you can now  use the app";
            }
            else
            {
                return $"An error occurred wgile confirming {user.Email}.";
            }
        }

        //FORGOTPASSWORD
        public async Task<ServiceResult> ForgotPassswordAsync(ForgotPasswordRequest request, string origin)
        {
            ServiceResult response = new()
            {
                HasError = false,
            };

            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                response.HasError = true;
                response.Error = $"No Accounts registered with {request.Email}";
                return response;
            }

            var verificationURI = await SendForgotPasswordUri(user, origin);

            await _emailServices.SendAsync(new Core.Application.Dtos.Email.EmailRequest()
            {
                To = user.Email,
                Body = $"Please reset your account visiting this URL {verificationURI}",
                Subject = "reset password"
            });

            return response;

        }


        //RESETPASSWORD
        public async Task<ServiceResult> ResetPasswordAsync(ResetPasswordRequest request)
        {
            ServiceResult response = new()
            {
                HasError = false,
            };

            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                response.HasError = true;
                response.Error = $"No Accounts registered with {request.Email}";
                return response;
            }

            request.Token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Token));
            var result = await _userManager.ResetPasswordAsync(user, request.Token, request.Password);

            if (!result.Succeeded)
            {
                response.HasError = true;
                response.Error = $"An error occurred while reset password";
                return response;
            }

            return response;
        }

        //SINGOUT
        public async Task SingOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        #region PrivateMethods

        //SENDFORGOTPASSWORDURI
        private async Task<string> SendForgotPasswordUri(ApplicationUser user, string origin)
        {
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var route = "User/ResetPassword";
            var Uri = new Uri(string.Concat($"{origin}/", route));
            var verificationUri = QueryHelpers.AddQueryString(Uri.ToString(), "Token", code);

            return verificationUri;
        }


        //SEMDVERIFICATIONURI
        private async Task<string> SendVerificationUri(ApplicationUser user, string origin)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var route = "User/ConfirmEmail";
            var Uri = new Uri(string.Concat($"{origin}/", route));
            var verificationUri = QueryHelpers.AddQueryString(Uri.ToString(), "userId", user.Id);
            verificationUri = QueryHelpers.AddQueryString(verificationUri, "Token", code);

            return verificationUri;
        }

        #endregion
    }
}
