using SedisBackend.Core.Domain.DTO.Shared;

namespace SedisBackend.Core.Domain.Interfaces.Services.Shared;

public interface IEmailService
{
    Task SendAsync(EmailRequest request);
}
