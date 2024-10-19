namespace SedisBackend.Core.Domain.DTO.Entities.Medical_History.Allergies;

public record AllergyDto
{
    public Guid Id { get; set; }
    public string Allergen { get; set; }
}
