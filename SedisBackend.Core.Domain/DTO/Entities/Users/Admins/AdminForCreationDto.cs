namespace SedisBackend.Core.Domain.DTO.Entities.Users.Admins;

public record AdminForCreationDto
{
    public Guid UserId { get; set; }
    public Guid HealthCenterId { get; set; }
}
