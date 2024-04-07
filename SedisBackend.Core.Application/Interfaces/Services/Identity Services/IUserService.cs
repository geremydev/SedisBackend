using SedisBackend.Core.Application.Dtos.Error;
using SedisBackend.Core.Application.Dtos.Identity_Dtos.Account;
using SedisBackend.Core.Application.Dtos.Identity_Dtos.Users;

namespace SedisBackend.Core.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> ConfirmEmailAsync(string userId, string token);
        Task<ServiceResult> ForgotPasssowrdAsync(ForgotPasswordDto vm, string origin);
        Task<AuthenticationResponse> LoginAsync(LoginDto vm);
        Task<ServiceResult> RegisterAsync(SaveUserDto vm, string origin);
        Task<ServiceResult> ResetPasssowrdAsync(ResetPasswordDto vm);
        Task SignOutAsync();
    }
}