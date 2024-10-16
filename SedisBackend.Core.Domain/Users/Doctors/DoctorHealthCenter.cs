using SedisBackend.Core.Domain.Health_Centers;

namespace SedisBackend.Core.Domain.Users.Doctors
{
    public class DoctorHealthCenter
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
