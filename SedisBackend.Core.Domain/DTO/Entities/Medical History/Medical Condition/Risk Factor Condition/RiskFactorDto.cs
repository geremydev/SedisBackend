using SedisBackend.Core.Domain.Enums;

namespace SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Risk_Factor_Condition;

public record RiskFactorDto
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public RiskFactorCodeType CodeType { get; set; }
    public string Description { get; set; }
    public RiskFactorCategory Category { get; set; }
    public RiskFactorAssessmentLevel AssessmentLevel { get; set; }
}
