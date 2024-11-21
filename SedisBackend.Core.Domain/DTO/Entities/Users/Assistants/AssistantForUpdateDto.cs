namespace SedisBackend.Core.Domain.DTO.Entities.Users.Assistants;

public record AssistantForUpdateDto
{
    public bool IsActive { get; set; }
    public Guid HealthCenterId { get; set; }
}
