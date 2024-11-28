namespace SedisBackend.Core.Domain.DTO.Entities.Medical_History.PatientDiscapacity;
public class PatientDiscapacityDto
{
    public Guid PatientId { get; set; }
    public Guid DiscapacityId { get; set; }
    // Fecha de diagnóstico (opcional)
    public DateTime? DiagnosisDate { get; set; }
    public string Severity { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
    public Guid MedicalConsultationId { get; set; }
}
