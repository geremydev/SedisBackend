using SedisBackend.Core.Domain.Entities.Models;

namespace SedisBackend.Core.Domain.Entities.Relations;

public class HealthCenterServices : IBaseEntity
{
    public Guid Id { get; set; }
    public Guid HealthCenterId { get; set; }
    public HealthCenter HealthCenter { get; set; }
    public Guid ServiceId { get; set; }
    public Service Service { get; set; }
    public DateTime CreationDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}
