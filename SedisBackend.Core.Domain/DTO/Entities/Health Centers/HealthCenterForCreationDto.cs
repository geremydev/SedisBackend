namespace SedisBackend.Core.Domain.DTO.Entities.Health_Centers;

public class HealthCenterForCreationDto
{
    public string Name { get; set; }
    public Guid? LocationId { get; set; }
    public string HealthCenterCategory { get; set; } //Primary ...
    public bool Status { get; set; } = true;
}
