namespace SedisBackend.Core.Domain.DTO.Entities.Medical_History.Allergies;

public record AllergyForCreationDto
{
    public Guid AllergyId { get; set; }
    public string Allergen {  get; set; }
}
