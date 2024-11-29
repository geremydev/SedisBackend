namespace SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Discapacity_Condition;

public class DiscapacityDto
{
    public Guid Id { get; set; }
    public string IcdCode { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
