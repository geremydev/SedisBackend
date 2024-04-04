using SedisBackend.Core.Application.Dtos.Account;
using SedisBackend.Core.Application.Dtos.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Interfaces.Services
{
    public interface IAccountServices
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
    }
}
