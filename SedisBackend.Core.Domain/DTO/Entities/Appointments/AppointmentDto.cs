namespace SedisBackend.Core.Domain.DTO.Entities.Appointments;

public class AppointmentDto
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public Guid HealthCenterId { get; set; }
    public string Status { get; set; }
    public string ConsultationType { get; set; }
    public string ConsultationRoom { get; set; }
}
