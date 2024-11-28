namespace SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Risk_Factor_Condition;

public record RiskFactorForCreationDto
{
    public string IcdCode { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
