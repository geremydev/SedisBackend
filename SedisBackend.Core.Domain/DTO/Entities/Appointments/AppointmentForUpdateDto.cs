namespace SedisBackend.Core.Domain.DTO.Entities.Appointments;

public class AppointmentForUpdateDto
{
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public Guid HealthCenterId { get; set; }
    public Guid MedicalConsultationId { get; set; }
    public string ConsultationType { get; set; }
    public string ConsultationRoom { get; set; }
    public string Status { get; set; }
    public AppointmentForUpdateDto()
    {

    }
}
