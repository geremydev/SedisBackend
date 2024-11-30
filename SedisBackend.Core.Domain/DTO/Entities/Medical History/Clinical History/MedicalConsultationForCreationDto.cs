namespace SedisBackend.Core.Domain.DTO.Entities.Medical_History.Clinical_History;

public class MedicalConsultationForCreationDto
{
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public Guid AppointmentId { get; set; }
    public string ReasonForVisit { get; set; }
    public string CurrentHistory { get; set; }
    public string? PhysicalExamination { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string Status { get; set; }
}
