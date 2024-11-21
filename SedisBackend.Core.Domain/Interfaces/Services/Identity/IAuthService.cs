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
    Task<string> RefreshTokenAsync(string token, string refreshToken);



    Task<ServiceResult> AddRole(string cardId, Guid healthCenterId, RolesEnum role);
    Task<ServiceResult> RemoveRole(string cardId, RolesEnum role);
    Task<ServiceResult> ChangeRoleStatus(string cardId, RolesEnum role, bool isActive);
    Task<ServiceResult> ChangeUserStatus(string cardId, bool isActive);
    Task<ServiceResult> DeleteUser(string cardId);
    Task<ServiceResult> RestoreUser(string cardId);
    Task<ServiceResult> CreateUser(CreateUserRequest request);
}
