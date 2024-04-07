using SedisBackend.Core.Application.Dtos.Shared_Dtos;

namespace SedisBackend.Core.Application.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
