using SedisBackend.Core.Domain.DTO.Error;
using SedisBackend.Core.Domain.DTO.Identity.Authentication;
using SedisBackend.Core.Domain.Enums;

namespace SedisBackend.Core.Domain.Interfaces.Services.Identity;

public interface IAuthService
{
    //Task<IdentityResult> RegisterUser(RegisterRequest registerRequest);
    //Task<bool> ValidateUser(AuthenticationRequest authenticationRequest);
    //Task<JwtSecurityToken> CreateToken(User user);
    Task<ServiceResult> ChangeUserStatus(RegisterRequest request);
    Task<DtoAccount> GetByEmail(string Email);
    Task Remove(DtoAccount account);
    Task<List<DtoAccount>> GetAllUsers();
    Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
    Task<ServiceResult> RegisterUserAsync(RegisterRequest request, string origin, RolesEnum userRole);
    Task<string> ConfirmAccountAsync(string userId, string token);
    Task<ServiceResult> ForgotPassswordAsync(ForgotPasswordRequest request, string origin);
    Task<ServiceResult> ResetPasswordAsync(ResetPasswordRequest request);
    Task SingOutAsync();
    Task<DtoAccount> GetByIdAsync(string UserId);
    //Task<ServiceResult> UpdateUserAsync(RegisterRequest request);
    Task<ServiceResult> AddRole(string CardId, Guid HealthCenterId, RolesEnum Role);
    Task<string> RefreshTokenAsync(string token, string refreshToken);
}
