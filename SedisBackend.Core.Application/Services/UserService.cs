using AutoMapper;
using SedisBackend.Core.Application.Dtos.Error;
using SedisBackend.Core.Application.Dtos.Identity_Dtos.Account;
using SedisBackend.Core.Application.Dtos.Identity_Dtos.Users;
using SedisBackend.Core.Application.Enums;
using SedisBackend.Core.Application.Interfaces.Loggers;
using SedisBackend.Core.Application.Interfaces.Services;

namespace SedisBackend.Core.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IAccountService _accountservice;
        private readonly IMapper _mapper;

        public UserService(IAccountService accountservice, ILoggerManager logger, IMapper mapper)
        {
            _accountservice = accountservice;
            _mapper = mapper;
        }

        public async Task<AuthenticationResponse> LoginAsync(LoginDto vm)
        {
            AuthenticationRequest loginrequest = _mapper.Map<AuthenticationRequest>(vm);

            AuthenticationResponse userResponse = await _accountservice.AuthenticateAsync(loginrequest);
            return userResponse;
        }


        public async Task SignOutAsync()
        {
            await _accountservice.SingOutAsync();
        }

        public async Task<ServiceResult> RegisterAsync(SaveUserDto vm, string origin )
        {
            RegisterRequest registerRequest = _mapper.Map<RegisterRequest>(vm);
            return await _accountservice.RegisterUserAsync(registerRequest, origin, RolesEnum.Patient.ToString());
        }

        public async Task<string> ConfirmEmailAsync(string userId, string token)
        {
            return await _accountservice.ConfirmAccountAsync(userId, token);
        }

        public async Task<ServiceResult> ForgotPasssowrdAsync(ForgotPasswordDto vm, string origin)
        {
            ForgotPasswordRequest forgotRequest = _mapper.Map<ForgotPasswordRequest>(vm);
            return await _accountservice.ForgotPassswordAsync(forgotRequest, origin);
        }

        public async Task<ServiceResult> ResetPasssowrdAsync(ResetPasswordDto vm)
        {
            ResetPasswordRequest resetRequest = _mapper.Map<ResetPasswordRequest>(vm);
            return await _accountservice.ResetPasswordAsync(resetRequest);
        }
    }
}
