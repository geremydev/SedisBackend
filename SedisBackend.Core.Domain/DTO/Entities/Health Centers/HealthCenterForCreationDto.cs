using SedisBackend.Core.Domain.Enums;

namespace SedisBackend.Core.Domain.DTO.Entities.Health_Centers;

public record HealthCenterForCreationDto
{
    public string Name { get; set; }
    public Guid? LocationId { get; set; }
    public HealthCenterCategory HealthCenterCategory { get; set; }
}
