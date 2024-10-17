using SedisBackend.Core.Domain.Users.Patients;

namespace SedisBackend.Core.Domain.Medical_History.Allergies
{
    public class PatientAllergy : IBaseEntity
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public Guid AllergyId { get; set; }
        public Allergy Allergy { get; set; }
        public string AllergicReaction { get; set; }
        public DateTime? DiagnosisDate { get; set; }
    }
}
