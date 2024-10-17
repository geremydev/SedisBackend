using SedisBackend.Core.Domain.Medical_History.Clinical_History;

namespace SedisBackend.Core.Domain.Prescriptions
{
    public class Prescription
    {
        public Guid Id { get; set; }
        public Guid ClinicalHistoryId { get; set; } 
        public ClinicalHistory ClinicalHistory { get; set; } // Navigation property
        public ICollection<MedicationPrescription>? PrescribedMedications { get; set; }
        public ICollection<LabTestPrescription>? PrescribedLabTests { get; set; }
        public string? OtherPrescriptions { get; set; }
    }
}
