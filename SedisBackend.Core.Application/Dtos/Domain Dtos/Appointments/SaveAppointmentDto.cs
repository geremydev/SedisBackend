using System.Text.Json.Serialization;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Appointments
{
    public class SaveAppointmentDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int HealthCenterId { get; set; }
        public string AppointmentStatus { get; set; } 
        public string ConsultationType { get; set; }
        public string ConsultationRoom { get; set; }
    }
}
