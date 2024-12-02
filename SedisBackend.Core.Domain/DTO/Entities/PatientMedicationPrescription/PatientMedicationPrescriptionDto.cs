using SedisBackend.Core.Domain.DTO.Entities.Products.Medication;
using SedisBackend.Core.Domain.Entities.Models.Products;

namespace SedisBackend.Core.Domain.DTO.Entities.PatientMedicationPrescription;
public class PatientMedicationPrescriptionDto
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Guid MedicationId { get; set; }
    public MedicationDto Medication { get; set; }
    public Guid? MedicalConsultationId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Notes { get; set; }
    public bool Status { get; set; }
}
