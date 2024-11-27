namespace SedisBackend.Core.Domain.DTO.Entities.Users.Admins;

public record AdminForUpdateDto
{
    public Guid UserId { get; set; }
    public Guid HealthCenterId { get; set; }
    public bool Status { get; set; }
}
