using SedisBackend.Core.Application.Dtos.Error;
using SedisBackend.Core.Application.Dtos.Identity_Dtos.Account;

namespace SedisBackend.Core.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<ServiceResult> ChangeUserStatus(RegisterRequest request);
        Task<DtoAccount> GetByEmail(string Email);
        Task Remove(DtoAccount account);
        Task<List<DtoAccount>> GetAllUsers();
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<ServiceResult> RegisterUserAsync(RegisterRequest request, string origin, string UserRoles);
        Task<string> ConfirmAccountAsync(string userId, string token);
        Task<ServiceResult> ForgotPassswordAsync(ForgotPasswordRequest request, string origin);
        Task<ServiceResult> ResetPasswordAsync(ResetPasswordRequest request);
        Task SingOutAsync();
        Task<DtoAccount> GetByIdAsync(string UserId);
        Task<ServiceResult> UpdateUserAsync(RegisterRequest request);
        Task<ServiceResult> AddRole(string IdCard, int HealthCenterId, string Role);
        Task<DomainEntitiesRelatedDto> GetDomainEntitiesByIdAsync(string Id);
    }
}
