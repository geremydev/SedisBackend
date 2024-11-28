namespace SedisBackend.Core.Domain.DTO.Entities.Users.LabTech;
public class LabTechDto
{
    public Guid Id { get; set; }
    public bool Status { get; set; }
    public Guid HealthCenterId { get; set; }
}
