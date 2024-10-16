namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Prescriptions
{
    public class SaveMedicationPrescriptionDto
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid MedicationId { get; set; }
        public Guid PrescriptionId { get; set; }
        public DateTime? TreatmentStart { get; set; }
        public DateTime? TreatmentEnd { get; set; }
        public string Dosage { get; set; } //Debe estar en un formato estandarizado
        public string Status { get; set; } //Usamos el enum MedicationConsuptionStatus 
    }
}
