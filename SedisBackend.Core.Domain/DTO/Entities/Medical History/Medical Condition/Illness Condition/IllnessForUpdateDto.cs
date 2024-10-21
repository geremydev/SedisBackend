namespace SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Illness_Condition;

public record IllnessForUpdateDto
{
    public string Code { get; set; }
    public string CodeType { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IllnessForUpdateDto()
    {

    }
}
