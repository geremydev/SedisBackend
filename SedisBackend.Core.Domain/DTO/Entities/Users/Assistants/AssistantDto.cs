using SedisBackend.Core.Domain.Entities.Models;

namespace SedisBackend.Core.Domain.DTO.Entities.Users.Assistants;

public record AssistantDto : BaseUserDto
{
    public Guid HealthCenterId { get; set; }
    public HealthCenter HealthCenter { get; set; }
}
