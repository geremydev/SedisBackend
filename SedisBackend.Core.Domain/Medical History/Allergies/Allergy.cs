namespace SedisBackend.Core.Domain.Medical_History.Allergies
{
    public class Allergy
    {
        public Guid Id { get; set; }
        public string Allergen { get; set; }
        public ICollection<PatientAllergy> Patients { get; set; }
    }
}
