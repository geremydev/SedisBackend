using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Medical_History.Allergies;

namespace SedisBackend.Core.Domain.Entities.Relations;

public class PatientAllergy 
{
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public Guid AllergyId { get; set; }
    public Allergy Allergy { get; set; }
    public string Allergen {  get; set; }
    public string AllergicReaction { get; set; }
    public DateTime? DiagnosisDate { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
}
