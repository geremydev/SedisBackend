using SedisBackend.Core.Domain.Appointments.Enums;
using SedisBackend.Core.Domain.Health_Centers;
using SedisBackend.Core.Domain.Users.Doctors;
using SedisBackend.Core.Domain.Users.Patients;

namespace SedisBackend.Core.Domain.Appointments
{
    public class Appointment
    {
        public int Id { get; set; }     
        public int PatientId { get; set; }  
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime AppointmentDate { get; set; } 
        public int HealthCenterId { get; set; }  
        public HealthCenter HealthCenter { get; set; } 
        public string AppointmentStatus { get; set; } // Indicates the current status of the appointment (e.g., scheduled, canceled, completed) using the AppointmentStatus enum
        public string ConsultationType { get; set; } // Specifies the type of consultation (e.g., general checkup, follow-up)
        public string ConsultationRoom { get; set; } 
    }
}
