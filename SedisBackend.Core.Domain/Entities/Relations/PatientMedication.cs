
using SedisBackend.Core.Domain.Entities.Models.Products;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;

namespace SedisBackend.Core.Domain.Entities.Relations;
public class PatientMedication : IBaseEntity
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Guid MedicationId { get; set; }
    public Medication Medication { get; set; }
    public Guid? MedicalConsultationId { get; set; }
    public MedicalConsultation MedicalConsultation { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Notes { get; set; }
    public bool Status { get; set; }
}
