using SedisBackend.Core.Domain.Appointments;
using SedisBackend.Core.Domain.Users.Doctors;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Health_Centers
{
    public class BaseHealthCenterDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? LocationId { get; set; }
        public string HealthCenterCategory { get; set; } // Usando enum HealthCenterCategory 
        public List<Appointment> Appointments { get; set; }
        public List<DoctorHealthCenter> Doctors { get; set; }
    }
}
