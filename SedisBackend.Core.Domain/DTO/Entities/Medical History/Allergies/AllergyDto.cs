namespace SedisBackend.Core.Domain.DTO.Entities.Medical_History.Allergies;

public class AllergyDto
{
    public Guid Id { get; set; }
    public string IcdCode { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
