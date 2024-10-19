namespace SedisBackend.Core.Domain.DTO.Entities.Medical_History.Vaccines;

public record VaccineForUpdateDto
{
    public string Name { get; set; }
    public string Disease { get; set; }
    public int Doses { get; set; }
    public string Laboratory { get; set; }
    public VaccineForUpdateDto()
    {

    }
}
