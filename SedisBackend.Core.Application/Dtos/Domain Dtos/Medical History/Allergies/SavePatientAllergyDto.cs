namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Allergies
{
    public class SavePatientAllergyDto
    {
        public Guid PatientId { get; set; }
        public Guid AllergyId { get; set; }
        public string AllergicReaction { get; set; }
        public DateTime? DiagnosisDate { get; set; }
    }
}
