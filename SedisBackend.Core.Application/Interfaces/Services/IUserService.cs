using SedisBackend.Core.Application.Dtos.Account;
using SedisBackend.Core.Application.Dtos.Error;
using SedisBackend.Core.Application.Dtos.Users;

namespace SedisBackend.Core.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> ConfirmEmailAsync(string userId, string token);
        Task<ServiceResult> ForgotPasssowrdAsync(ForgotPasswordViewModel vm, string origin);
        Task<AuthenticationResponse> LoginAsync(LoginViewModel vm);
        Task<ServiceResult> RegisterAsync(SaveUserViewModel vm, string origin);
        Task<ServiceResult> ResetPasssowrdAsync(ResetPasswordViewModel vm);
        Task SignOutAsync();
    }
}