namespace SedisBackend.Core.Domain.DTO.Entities.Medical_History.Allergies;
public class PatientAllergyForCreationDto
{
    public Guid PatientId { get; set; }
    public Guid AllergyId { get; set; }
    public string? Allergen { get; set; }
    public string? AllergicReaction { get; set; }
    public string? Description { get; set; }
    public DateTime DiagnosisDate { get; set; } = DateTime.Now;
    public bool Status { get; set; }
}

