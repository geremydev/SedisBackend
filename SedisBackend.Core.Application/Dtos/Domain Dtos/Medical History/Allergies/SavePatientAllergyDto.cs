using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Patients;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Allergies
{
    public class SavePatientAllergyDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int AllergyId { get; set; }
        public string AllergicReaction { get; set; }
        public DateTime? DiagnosisDate { get; set; }
    }
}
