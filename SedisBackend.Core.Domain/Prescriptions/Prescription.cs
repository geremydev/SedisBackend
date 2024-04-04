using SedisBackend.Core.Domain.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Products;

namespace SedisBackend.Core.Domain.Prescriptions
{
    public class Prescription
    {
        public int Id { get; set; }
        public int ClinicalHistoryId { get; set; } 
        public ClinicalHistory ClinicalHistory { get; set; } // Navigation property
        public ICollection<MedicationPrescription>? PrescribedMedications { get; set; }
        public ICollection<LabTestPrescription>? PrescribedLabTests { get; set; }
        public string? OtherPrescriptions { get; set; }
        public string? Extra { get; set; } // Special instructions for the medication (nullable)
    }
}
