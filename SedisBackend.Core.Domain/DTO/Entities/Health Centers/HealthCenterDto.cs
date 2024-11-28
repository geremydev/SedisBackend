namespace SedisBackend.Core.Domain.DTO.Entities.Health_Centers;

public record HealthCenterDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid? LocationId { get; set; }
    public string HealthCenterCategory { get; set; } 
    public bool Status { get; set; }
}