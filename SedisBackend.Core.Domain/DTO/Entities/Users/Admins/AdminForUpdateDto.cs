namespace SedisBackend.Core.Domain.DTO.Entities.Users.Admins;

public class AdminForUpdateDto
{
    public Guid UserId { get; set; }
    public Guid HealthCenterId { get; set; }
    public bool Status { get; set; }
}
