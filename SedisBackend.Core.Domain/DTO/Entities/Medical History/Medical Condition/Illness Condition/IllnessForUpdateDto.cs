namespace SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Illness_Condition;

public record IllnessForUpdateDto
{
    public string IcdCode { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public IllnessForUpdateDto() { }
}
