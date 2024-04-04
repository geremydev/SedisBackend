using SedisBackend.Core.Domain.Medical_History.Clinical_History;

namespace SedisBackend.Core.Domain.Presctiptions
{
    public class Prescription
    {
        public int Id { get; set; }
        public int ClinicalHistoryId { get; set; } 
        public ClinicalHistory ClinicalHistory { get; set; } // Navigation property
        public ICollection<MedicationPrescription> PrescribedMedications { get; set; } 
        public DateTime TreatmentStart { get; set; }
        public DateTime TreatmentEnd { get; set; }
        public string? Instructions { get; set; } // Special instructions for the medication (nullable)
    }
}
