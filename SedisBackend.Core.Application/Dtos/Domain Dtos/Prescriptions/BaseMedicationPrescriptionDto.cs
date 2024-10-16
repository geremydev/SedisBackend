namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Prescriptions
{
    public class BaseMedicationPrescriptionDto
    {
        public Guid Id { get; set; }
        //public int PatientId { get; set; }
        //public Patient Patient { get; set; }
        public Guid MedicationId { get; set; }
        //public Medication Medication { get; set; }
        public Guid PrescriptionId { get; set; }
        //public Prescription Prescription { get; set; }
        public DateTime? TreatmentStart { get; set; }
        public DateTime? TreatmentEnd { get; set; }
        public string Dosage { get; set; } //Debe estar en un formato estandarizado
        public string Status { get; set; } //Usamos el enum MedicationConsuptionStatus 
    }
}
