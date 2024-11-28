namespace SedisBackend.Core.Domain.DTO.Entities.Medical_History.Allergies;

public record AllergyForUpdateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public AllergyForUpdateDto() { }
}
