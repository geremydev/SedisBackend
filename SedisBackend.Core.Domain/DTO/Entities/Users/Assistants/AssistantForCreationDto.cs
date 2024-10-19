namespace SedisBackend.Core.Domain.DTO.Entities.Users.Assistants;

public record AssistantForCreationDto : BaseUserForCreationDto
{
    public Guid HealthCenterId { get; set; }
}
