namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Doctors
{
    public class SaveDoctorHealthCenterDto
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public Guid HealthCenterId { get; set; }
        public TimeSpan EntryHour { get; set; } //HH:MM:SS.FFF
        public TimeSpan ExitHour { get; set; } //HH:MM:SS.FFF
    }
}
