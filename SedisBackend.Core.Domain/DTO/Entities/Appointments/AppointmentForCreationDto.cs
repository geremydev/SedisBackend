namespace SedisBackend.Core.Domain.DTO.Entities.Appointments;

public class AppointmentForCreationDto
{
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public Guid HealthCenterId { get; set; }
    public string AppointmentStatus { get; set; }
    public string ConsultationType { get; set; }
    public string ConsultationRoom { get; set; }
}
