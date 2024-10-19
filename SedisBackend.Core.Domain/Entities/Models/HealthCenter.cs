using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Entities.Users.Persons;

namespace SedisBackend.Core.Domain.Entities.Models;

public class HealthCenter : IBaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid? LocationId { get; set; }
    public string HealthCenterCategory { get; set; } // Usando enum HealthCenterCategory 
    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<DoctorHealthCenter> Doctors { get; set; }
    public ICollection<Admin> Admins { get; set; }
    public ICollection<Assistant> Assistants { get; set; }
    public ICollection<HealthCenterServices> Services { get; set; }
}
