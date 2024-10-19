using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Medical_History.Allergies;

namespace SedisBackend.Core.Domain.Entities.Relations;

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
