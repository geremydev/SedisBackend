using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Medical_History.Allergies;
using System.Text.Json.Serialization;

namespace SedisBackend.Core.Domain.DTO.Entities.Medical_History.Allergies;
public class PatientAllergyDto
{
    public Guid PatientId { get; set; }
    public Guid AllergyId { get; set; }
    [JsonIgnore]
    public string? Allergen { get; set; }
    public DateTime? DiagnosisDate { get; set; }
    public string? AllergicReaction { get; set; }
    public bool Status { get; set; }
    public string? Description { get; set; }
}
