using SedisBackend.Core.Domain.DTO.Error;
using SedisBackend.Core.Domain.DTO.Identity.Authentication;
using SedisBackend.Core.Domain.DTO.Identity.Users;

namespace SedisBackend.Core.Domain.Interfaces.Services.Identity;

public interface IUserService
{
    Task<string> ConfirmEmailAsync(string userId, string token);
    Task<ServiceResult> ForgotPasssowrdAsync(ForgotPasswordDto vm, string origin);
    Task<AuthenticationResponse> LoginAsync(LoginDto vm);
    Task<ServiceResult> RegisterAsync(SaveUserDto vm, string origin);
    Task<ServiceResult> ResetPasssowrdAsync(ResetPasswordDto vm);
    Task SignOutAsync();
}