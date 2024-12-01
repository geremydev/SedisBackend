namespace SedisBackend.Core.Domain.DTO.Entities.Health_Centers;

public class HealthCenterForUpdateDto
{
    public string Name { get; set; }
    public Guid? LocationId { get; set; }
    public string HealthCenterCategory { get; set; }
    public bool Status { get; set; }
    public string Details { get; set; }
    public string LocationString { get; set; }
    public HealthCenterForUpdateDto()
    {

    }
}
