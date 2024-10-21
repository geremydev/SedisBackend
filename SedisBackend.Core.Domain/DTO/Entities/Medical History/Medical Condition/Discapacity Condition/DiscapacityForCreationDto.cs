namespace SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Discapacity_Condition;

public record DiscapacityForCreationDto
{
    public string Type { get; set; }
    public string Description { get; set; }
}
