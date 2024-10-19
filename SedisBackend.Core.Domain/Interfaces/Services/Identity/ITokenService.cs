using SedisBackend.Core.Domain.DTO.Identity.Authentication;
using SedisBackend.Core.Domain.Entities.Users;

namespace SedisBackend.Core.Domain.Interfaces.Services.Identity;
public interface ITokenService
{
    Task<string> CreateToken(User user);
    RefreshToken GenerateRefreshToken();
    Task<string> RefreshTokenAsync(string token, string refreshToken);
}