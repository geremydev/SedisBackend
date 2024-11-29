
using SedisBackend.Core.Domain.Entities.Models.Products;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Medical_History.MedicalConsultation;

namespace SedisBackend.Core.Domain.Entities.Relations;
public class PatientMedicationPrescription
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public Guid MedicationId { get; set; }
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public Medication Medication { get; set; }
    public Guid? MedicalConsultationId { get; set; }
    public MedicalConsultation MedicalConsultation { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Notes { get; set; }
    public bool Status { get; set; }
}
