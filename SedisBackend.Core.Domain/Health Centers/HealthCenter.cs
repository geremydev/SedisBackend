using SedisBackend.Core.Domain.Appointments;
using SedisBackend.Core.Domain.Health_Centers.Enums;

namespace SedisBackend.Core.Domain.Health_Centers
{
    public class HealthCenter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? LocationId { get; set; }
        public string HealthCenterCategory { get; set; } // Usando enum HealthCenterCategory 
        public List<Appointment> Appointments { get; set; }
    }
}
