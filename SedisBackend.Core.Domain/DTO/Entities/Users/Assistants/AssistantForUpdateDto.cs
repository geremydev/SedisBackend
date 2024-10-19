namespace SedisBackend.Core.Domain.DTO.Entities.Users.Assistants;

public record AssistantForUpdateDto : BaseUserForUpdateDto
{
    public Guid HealthCenterId { get; set; }
}
