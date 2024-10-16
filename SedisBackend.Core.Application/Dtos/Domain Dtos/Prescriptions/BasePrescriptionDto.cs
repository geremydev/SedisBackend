using SedisBackend.Core.Domain.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Prescriptions;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Prescriptions
{
    public class BasePrescriptionDto
    {
        public Guid Id { get; set; }
        public Guid ClinicalHistoryId { get; set; }
        public ClinicalHistory ClinicalHistory { get; set; } // Navigation property
        public List<MedicationPrescription>? PrescribedMedications { get; set; }
        public List<LabTestPrescription>? PrescribedLabTests { get; set; }
        public string? OtherPrescriptions { get; set; }
        public string? Extra { get; set; } // Special instructions for the medication (nullable)
    }
}
