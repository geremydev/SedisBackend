using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Core.Domain.DTO.Entities.Health_Centers;

public record HealthCenterDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid? LocationId { get; set; }
    public string HealthCenterCategory { get; set; } // Usando enum HealthCenterCategory 
    public List<Appointment> Appointments { get; set; }
    public List<DoctorHealthCenter> Doctors { get; set; }
}
