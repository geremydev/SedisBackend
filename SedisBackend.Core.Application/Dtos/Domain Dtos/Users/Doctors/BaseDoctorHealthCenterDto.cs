using SedisBackend.Core.Domain.Health_Centers;
using SedisBackend.Core.Domain.Users.Doctors;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Doctors
{
    public class BaseDoctorHealthCenterDto
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public Guid HealthCenterId { get; set; }
        public HealthCenter HealthCenter { get; set; }
        public TimeSpan EntryHour { get; set; } //HH:MM:SS.FFF
        public TimeSpan ExitHour { get; set; } //HH:MM:SS.FFF
    }
}
