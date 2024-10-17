namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Prescriptions
{
    public class SavePrescriptionDto
    {
        public Guid ClinicalHistoryId { get; set; }
        public string? OtherPrescriptions { get; set; }
        public string? Extra { get; set; } // Special instructions for the medication (nullable)
    }
}
