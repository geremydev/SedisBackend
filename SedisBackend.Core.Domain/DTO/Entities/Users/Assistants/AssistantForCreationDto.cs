namespace SedisBackend.Core.Domain.DTO.Entities.Users.Assistants;

public record AssistantForCreationDto 
{
    public Guid UserId { get; set; }
    public Guid HealthCenterId { get; set; }
}
