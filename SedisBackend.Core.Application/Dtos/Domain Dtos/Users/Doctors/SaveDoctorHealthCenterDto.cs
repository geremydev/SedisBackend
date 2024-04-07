using System.Text.Json.Serialization;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Doctors
{
    public class SaveDoctorHealthCenterDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int HealthCenterId { get; set; }
        public TimeSpan EntryHour { get; set; } //HH:MM:SS.FFF
        public TimeSpan ExitHour { get; set; } //HH:MM:SS.FFF
    }
}
