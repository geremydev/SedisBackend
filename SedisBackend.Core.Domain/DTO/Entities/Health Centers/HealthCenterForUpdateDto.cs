namespace SedisBackend.Core.Domain.DTO.Entities.Health_Centers;

public record HealthCenterForUpdateDto
{
    public string Name { get; set; }
    public Guid? LocationId { get; set; }
    public string HealthCenterCategory { get; set; }
    public HealthCenterForUpdateDto()
    {

    }
}
