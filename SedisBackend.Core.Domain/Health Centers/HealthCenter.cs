using SedisBackend.Core.Domain.Appointments;
using SedisBackend.Core.Domain.Users.Admins;
using SedisBackend.Core.Domain.Users.Assistants;
using SedisBackend.Core.Domain.Users.Doctors;

namespace SedisBackend.Core.Domain.Health_Centers
{
    public class HealthCenter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? LocationId { get; set; }
        public string HealthCenterCategory { get; set; } // Usando enum HealthCenterCategory 
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<DoctorHealthCenter> Doctors { get; set; }
        public ICollection<Admin> Admins { get; set; }
        public ICollection<Assistant> Assistants { get; set; }
        public ICollection<HealthCenterServices> Services { get; set; }
    }
}
