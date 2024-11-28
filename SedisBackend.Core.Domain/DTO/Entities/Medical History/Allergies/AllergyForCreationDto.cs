namespace SedisBackend.Core.Domain.DTO.Entities.Medical_History.Allergies;

public record AllergyForCreationDto
{
    public string IcdCode { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
