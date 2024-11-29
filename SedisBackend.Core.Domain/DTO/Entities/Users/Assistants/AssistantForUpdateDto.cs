namespace SedisBackend.Core.Domain.DTO.Entities.Users.Assistants;

public record AssistantForUpdateDto
{
    public bool Status { get; set; }
    public Guid HealthCenterId { get; set; }
}
