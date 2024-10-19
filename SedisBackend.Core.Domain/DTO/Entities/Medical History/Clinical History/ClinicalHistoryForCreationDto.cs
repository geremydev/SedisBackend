namespace SedisBackend.Core.Domain.DTO.Entities.Medical_History.Clinical_History;

public record ClinicalHistoryForCreationDto
{
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public string ReasonForVisit { get; set; }
    public string CurrentHistory { get; set; }
    public string? PhysicalExamination { get; set; }
    public string? Diagnosis { get; set; }
}
