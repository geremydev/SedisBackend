using SedisBackend.Core.Application.Dtos.Email;

namespace SedisBackend.Core.Application.Interfaces.Services
{
    public interface IEmailServices
    {
        Task SendAsync(EmailRequest request);
    }
}
