namespace SedisBackend.Core.Domain.DTO.Entities.PatientMedicationPrescription;
public class PatientMedicationPrescriptionForUpdateDto
{
    public Guid PatientId { get; set; }
    public Guid MedicationId { get; set; }
    public Guid? MedicalConsultationId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Notes { get; set; }
    public bool Status { get; set; }
    public PatientMedicationPrescriptionForUpdateDto()
    {
        
    }
}
