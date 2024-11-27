using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Entities.Users.Persons;

namespace SedisBackend.Core.Domain.Entities.Models;

public class HealthCenter : IBaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid? LocationId { get; set; }
    public string HealthCenterCategory { get; set; } //Primary ...
    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<Doctor> Doctors { get; set; }
    public ICollection<Admin> Admins { get; set; }
    public ICollection<Assistant> Assistants { get; set; }
    public ICollection<HealthCenterServices> HealthCenterServices { get; set; }
}
