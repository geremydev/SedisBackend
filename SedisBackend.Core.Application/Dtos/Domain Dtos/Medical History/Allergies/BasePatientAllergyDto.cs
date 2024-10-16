using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Patients;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Allergies
{
    public class BasePatientAllergyDto
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public BasePatientDto Patient { get; set; }
        public Guid AllergyId { get; set; }
        public BaseAllergyDto Allergy { get; set; }
        public string AllergicReaction { get; set; }
        public DateTime? DiagnosisDate { get; set; }
    }
}
