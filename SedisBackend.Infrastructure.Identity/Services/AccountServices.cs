using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Patients;
using SedisBackend.Core.Application.Dtos.Error;
using SedisBackend.Core.Application.Dtos.Identity_Dtos.Account;
using SedisBackend.Core.Application.Dtos.Shared_Dtos;
using SedisBackend.Core.Application.Helpers;
using SedisBackend.Core.Application.Interfaces.Services;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Patients;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.User_Entity_Relation;
using SedisBackend.Core.Domain.Settings;
using SedisBackend.Core.Domain.UserEntityRelation;
using SedisBackend.Infrastructure.Identity.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.User_Entity_Relation;
using SedisBackend.Core.Application.Enums;
using SedisBackend.Core.Application.Interfaces.Services.Shared_Services;
using SedisBackend.Infrastructure.Shared.Services;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Admins;
using SedisBackend.Core.Domain.Users.Admins;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Admins;
using System.Text.Json.Serialization;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Assistants;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Assistants;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Doctors;

namespace SedisBackend.Infrastructure.Identity.Services
{
    public class AccountServices: IAccountService
    {
        private readonly IPatientService _patientService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailService _emailServices;
        private readonly JWTSettings _jwtSettings;
        private readonly IMapper _mapper;
        private readonly IUserEntityRelationService _userEntityRelationService;
        private readonly ICardValidationService _cardValidationService;
        private readonly IAdminService _adminService;
        private readonly IAssistantService _assistantService;
        private readonly IDoctorService _doctorService;

        public AccountServices(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IEmailService emailServices,
            IMapper mapper, JWTSettings jwtSettings,IPatientService patientService,
            IUserEntityRelationService userEntityRelationService,
            ICardValidationService cardValidationService,
            IAdminService adminService,
            IAssistantService assistantService,
            IDoctorService doctorService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailServices = emailServices;
            _jwtSettings = jwtSettings;
            _mapper = mapper;
            _patientService = patientService;
            _userEntityRelationService = userEntityRelationService;
            _cardValidationService = cardValidationService;
            _adminService = adminService;
            _assistantService = assistantService;
            _doctorService = doctorService;
        }

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

            JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);

            response.Id = user.Id;
            response.Email = user.Email;
            response.UserName = user.UserName;

            var roleList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);

            response.Roles = roleList.ToList();
            response.IsVerified = user.EmailConfirmed;
            response.ImageUrl = user.ImageUrl;
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            var refreshToken = GenerateRefreshToken();
            response.RefreshToken = refreshToken.Token;
            response.DomainEntitiesRelated = await GetDomainEntitiesByIdAsync(user.Id);
            return response;
        }


        public async Task SingOutAsync()
        {
            await _signInManager.SignOutAsync();
        }


        //GETBYID
        public async Task<ServiceResult> RegisterUserAsync(RegisterRequest request, string origin, string UserRoles)
        {
            ServiceResult response = new()
            {
                HasError = true,
            };
            var cardValidation =  await _cardValidationService.VerifyCardId(request.IdCard);
            if (!cardValidation.valid)
            {
                response.Error = "Cédula inválida";
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

            var patient = _mapper.Map<SavePatientDto>(request);
            var p = await _patientService.AddAsync(patient);

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {

                var userDto = await _userManager.FindByEmailAsync(user.Email);

                var userEntityRelation = new UserEntityRelation
                {
                    UserId = userDto.Id,
                    EntityId = p.Id,
                    EntityRole = RolesEnum.Patient.ToString()
                };

                var userEntityRelationDto = _mapper.Map<SaveUserEntityRelationDto>(userEntityRelation);

                await _userEntityRelationService.AddAsync(userEntityRelationDto);

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



        //CONFIRMACCOUNT

        //FORGOTPASSWORD


        //RESETPASSWORD

        //SINGOUT

        #region PrivateMethods



        private async Task<JwtSecurityToken> GenerateJWToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                roleClaims.Add(new Claim("roles", role));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmectricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredetials = new SigningCredentials(symmectricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredetials);

            return jwtSecurityToken;
        }


        private RefreshToken GenerateRefreshToken()
        {
            return new RefreshToken
            {
                Token = RandomTokenString(),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow
            };
        }



        private string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var ramdomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(ramdomBytes);

            return BitConverter.ToString(ramdomBytes).Replace("-", "");
        }

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
            var route = "api/account/confirm-email";
            var Uri = new Uri(string.Concat($"{origin}/", route));
            var verificationUri = QueryHelpers.AddQueryString(Uri.ToString(), "userId", user.Id);
            verificationUri = QueryHelpers.AddQueryString(verificationUri, "Token", code);

            return verificationUri;
        }

        #endregion


        public async Task<ServiceResult> AddRole(string IdCard, int HealthCenterId, string Role)
        {
            SaveAdminDto admin = new();
            SaveAssistantDto assistant = new();
            ServiceResult serviceResult = new() { HasError = false };
            SaveUserEntityRelationDto userEntityRelation = new();

            var allPatients = await _patientService.GetAllAsync();
            var patient = allPatients.Find(p => p.IdCard == IdCard);
            var allUER = await _userEntityRelationService.GetAllAsync();
            var specificUER = allUER.Find(u => u.EntityId == patient.Id);
            var identityUser = await GetByIdAsync(specificUER.UserId);

            if(Role == RolesEnum.Admin.ToString())
            {
                admin = _mapper.Map<SaveAdminDto>(patient);
                admin.HealthCenterId = HealthCenterId;
                admin.Id = 0;
            }
            else if(Role == RolesEnum.Assistant.ToString())
            {
                assistant = _mapper.Map<SaveAssistantDto>(patient);
                assistant.HealthCenterId = HealthCenterId;
                assistant.Id = 0;
            }
            //Todavía no funciona, almacena el Entity Id en la tabla UserEntityRelation como 0, pero al menos ya lo almacena y actualiza los roles.

            try
            {
                if(Role == RolesEnum.Admin.ToString())
                {

                    admin = await _adminService.AddAsync(admin);
                    userEntityRelation = new SaveUserEntityRelationDto
                    {
                        UserId = identityUser.Id,
                        EntityId = admin.Id,
                        EntityRole = RolesEnum.Admin.ToString()
                    };
                }
                else if(Role == RolesEnum.Assistant.ToString())
                {
                    assistant = await _assistantService.AddAsync(assistant);
                    userEntityRelation = new SaveUserEntityRelationDto
                    {
                        UserId = identityUser.Id,
                        EntityId = assistant.Id,
                        EntityRole = RolesEnum.Assistant.ToString()
                    };
                }

                await _userEntityRelationService.AddAsync(userEntityRelation);
                
                await _userManager.AddToRoleAsync(await _userManager.FindByIdAsync(identityUser.Id), Role == RolesEnum.Admin.ToString()? RolesEnum.Admin.ToString() : RolesEnum.Assistant.ToString());

                serviceResult.HasError = false;
            }
            catch (Exception ex)
            {
                serviceResult.HasError = true;
                serviceResult.Error = ex.Message;
            }
            return serviceResult;
        }

        public async Task<DomainEntitiesRelatedDto> GetDomainEntitiesByIdAsync(string Id)
        {
            DomainEntitiesRelatedDto domainEntitiesRelatedDto = new();

            var identityUser = await _userManager.FindByIdAsync(Id);
            var entitiesRelated = await _userEntityRelationService.GetByUserIdAsync(identityUser.Id);
            if (entitiesRelated.Exists(e => e.EntityRole == RolesEnum.Patient.ToString()))
            {
                var uerEntity = entitiesRelated.Find(e => e.EntityRole == RolesEnum.Patient.ToString());
                domainEntitiesRelatedDto.Patient = await _patientService.GetByIdAsync(uerEntity.EntityId);
                domainEntitiesRelatedDto.Patient.Allergies = null;
                domainEntitiesRelatedDto.Patient.Discapacities = null;
                domainEntitiesRelatedDto.Patient.Illnesses = null;
                domainEntitiesRelatedDto.Patient.RiskFactors = null;
                domainEntitiesRelatedDto.Patient.Appointments = null;
                domainEntitiesRelatedDto.Patient.Vaccines = null;
                domainEntitiesRelatedDto.Patient.ClinicalHistories = null;
                domainEntitiesRelatedDto.Patient.FamilyHistories = null;
            }
            if (entitiesRelated.Exists(e=>e.EntityRole == RolesEnum.Admin.ToString()))
            {
                var uerEntity = entitiesRelated.Find(e => e.EntityRole == RolesEnum.Admin.ToString());
                domainEntitiesRelatedDto.Admin = await _adminService.GetByIdAsync(uerEntity.EntityId);
            }
            if (entitiesRelated.Exists(e => e.EntityRole == RolesEnum.Admin.ToString()))
            {
                var uerEntity = entitiesRelated.Find(e => e.EntityRole == RolesEnum.Assistant.ToString());
                domainEntitiesRelatedDto.Assistant = await _assistantService.GetByIdAsync(uerEntity.EntityId);
            }
            if (entitiesRelated.Exists(e => e.EntityRole == RolesEnum.Doctor.ToString()))
            {
                var uerEntity = entitiesRelated.Find(e => e.EntityRole == RolesEnum.Doctor.ToString());
                domainEntitiesRelatedDto.Doctor = await _doctorService.GetByIdAsync(uerEntity.EntityId);
            }
            return domainEntitiesRelatedDto;
        }
    }
}
