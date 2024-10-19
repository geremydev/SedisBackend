using SedisBackend.Core.Domain.Entities;
using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Core.Domain.Medical_History.Allergies;

public class Allergy : IBaseEntity
{
    public Guid Id { get; set; }
    public string Allergen { get; set; }
    public ICollection<PatientAllergy> Patients { get; set; }
}
