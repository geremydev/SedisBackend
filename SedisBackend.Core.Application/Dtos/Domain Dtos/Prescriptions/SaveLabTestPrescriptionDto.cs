namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Prescriptions
{
    public class SaveLabTestPrescriptionDto
    {
        public Guid ClinicalHistoryId { get; set; }
        public Guid LabTestId { get; set; }
        public Guid PrescriptionId { get; set; }
        //public Prescription Prescription { get; set; }
        public string Status { get; set; } // Usamos el enum LabTestStatus
        public DateTime PerformedDate { get; set; }
        public string ResultUrl { get; set; }
    }
}
