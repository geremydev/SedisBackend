using SedisBackend.Core.Domain.DTO.Shared;

namespace SedisBackend.Core.Domain.Interfaces.Services.Shared;

public interface ICardValidationService
{
    public Task<IdVerificationDto> VerifyCardId(string CardId);
}
