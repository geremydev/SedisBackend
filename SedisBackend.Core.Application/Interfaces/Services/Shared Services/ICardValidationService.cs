using SedisBackend.Core.Application.Dtos.Shared_Dtos;

namespace SedisBackend.Core.Application.Interfaces.Services.Shared_Services
{
    public interface ICardValidationService
    {
        public Task<IdVerificationDto> VerifyCardId(string IdCard);
    }
}
