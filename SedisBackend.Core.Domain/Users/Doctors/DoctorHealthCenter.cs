using SedisBackend.Core.Domain.Health_Centers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Domain.Users.Doctors
{
    public class DoctorHealthCenter
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int HealthCenterId { get; set; }
        public HealthCenter HealthCenter { get; set; }
        public TimeSpan EntryHour { get; set; } //HH:MM:SS.FFF
        public TimeSpan ExitHour { get; set; } //HH:MM:SS.FFF
    }
}
