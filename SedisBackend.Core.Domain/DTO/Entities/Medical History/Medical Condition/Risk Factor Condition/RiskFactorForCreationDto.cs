namespace SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Risk_Factor_Condition;

public record RiskFactorForCreationDto
{
    public string Code { get; set; }
    public string CodeType { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string AssessmentLevel { get; set; }
}
