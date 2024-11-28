namespace SedisBackend.Core.Domain.DTO.Entities.Users.LabTech;
public class LabTechForCreationDto
{
    public Guid UserId { get; set; }
    public bool Status { get; set; }
    public Guid HealthCenterId { get; set; }
}
