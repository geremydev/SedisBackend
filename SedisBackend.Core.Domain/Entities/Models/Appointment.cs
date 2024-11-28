using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;

namespace SedisBackend.Core.Domain.Entities.Models;

public class Appointment : IBaseEntity
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public DateTime AppointmentDate { get; set; }
    public Guid HealthCenterId { get; set; }
    public HealthCenter HealthCenter { get; set; }
    public string Status { get; set; } // Indicates the current status of the appointment (e.g., scheduled, canceled, completed)
    public string ConsultationRoom { get; set; }
    public Guid? MedicalConsultationId { get; set; }
    public MedicalConsultation? MedicalConsultation { get; set; }
}
