namespace SedisBackend.Core.Domain.DTO.Entities.Users.Admins;

public record AdminForCreationDto : BaseUserForCreationDto
{
    public Guid HealthCenterId { get; set; }
}
