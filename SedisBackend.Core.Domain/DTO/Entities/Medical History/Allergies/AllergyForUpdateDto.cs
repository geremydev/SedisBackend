namespace SedisBackend.Core.Domain.DTO.Entities.Medical_History.Allergies;

public record AllergyForUpdateDto
{
    public string Allergen { get; set; }
    public AllergyForUpdateDto()
    {

    }
}
