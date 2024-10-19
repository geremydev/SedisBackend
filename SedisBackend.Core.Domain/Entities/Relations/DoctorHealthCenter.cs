using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Entities.Users.Persons;

namespace SedisBackend.Core.Domain.Entities.Relations;

public class DoctorHealthCenter : IBaseEntity
{
    public Guid Id { get; set; }
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public Guid HealthCenterId { get; set; }
    public HealthCenter HealthCenter { get; set; }
    public TimeSpan EntryHour { get; set; } //HH:MM:SS.FFF
    public TimeSpan ExitHour { get; set; } //HH:MM:SS.FFF
}
