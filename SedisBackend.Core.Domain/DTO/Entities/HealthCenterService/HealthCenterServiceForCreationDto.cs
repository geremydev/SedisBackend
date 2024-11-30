namespace SedisBackend.Core.Domain.DTO.Entities.HealthCenterService;
public class HealthCenterServiceForCreationDto
{
    public Guid HealthCenterId { get; set; }
    public Guid ServiceId { get; set; }
    public DateTime CreationDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public bool Status { get; set; } = true;
}
