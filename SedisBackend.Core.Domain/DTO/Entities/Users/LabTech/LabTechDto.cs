using SedisBackend.Core.Domain.DTO.Entities.Health_Centers;

namespace SedisBackend.Core.Domain.DTO.Entities.Users.LabTech;
public class LabTechDto : BaseUserDto
{
    public Guid Id { get; set; }
    public bool Status { get; set; }
    public Guid HealthCenterId { get; set; }
    public HealthCenterDto HealthCenter { get; set; }
}
