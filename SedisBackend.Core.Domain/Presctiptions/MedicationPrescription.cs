using SedisBackend.Core.Domain.Products;

namespace SedisBackend.Core.Domain.Presctiptions
{
    public class MedicationPrescription
    {
        public int Id { get; set; }
        public string PatientId { get; set; }
        public int  MedicationId { get; set; }
        public Medication Medication { get; set; }
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
        public string Dosage { get; set; } //Debe estar en un formato estandarizado
        public string Status { get; set; } //Usamos el enum MedicationConsuptionStatus 
    }
}
