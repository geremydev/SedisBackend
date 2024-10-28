using SedisBackend.Core.Domain.DTO.Entities.Health_Centers;

namespace SedisBackend.Core.Domain.DTO.Entities.Users.Assistants;

public record AssistantDto : BaseUserDto
{
    //public Guid HealthCenterId { get; set; }
    public HealthCenterDto HealthCenter { get; set; }
}
