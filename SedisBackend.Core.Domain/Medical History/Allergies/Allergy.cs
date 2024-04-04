using SedisBackend.Core.Domain.Users.Patients;

namespace SedisBackend.Core.Domain.Medical_History.Allergies
{
    public class Allergy
    {
        public int Id { get; set; }
        public string Allergen { get; set; }
        public ICollection<PatientAllergy> Patients { get; set; }
    }
}
