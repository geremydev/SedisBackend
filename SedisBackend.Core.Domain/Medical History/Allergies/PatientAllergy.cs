using SedisBackend.Core.Domain.Users.Patients;

namespace SedisBackend.Core.Domain.Medical_History.Allergies
{
    public class PatientAllergy
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int AllergyId { get; set; }
        public Allergy Allergy { get; set; }
        public string AllergicReaction { get; set; }
        public DateTime? DiagnosisDate { get; set; }
    }
}
