using SedisBackend.Core.Domain.Appointments;
using SedisBackend.Core.Domain.Users.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Health_Centers
{
    public class BaseHealthCenterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? LocationId { get; set; }
        public string HealthCenterCategory { get; set; } // Usando enum HealthCenterCategory 
        public List<Appointment> Appointments { get; set; }
        public List<DoctorHealthCenter> Doctors { get; set; }
    }
}
