using SedisBackend.Core.Domain.Entities;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Enums;

namespace SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Risk_Factor;

public class RiskFactor : IBaseEntity
{
    public Guid Id { get; set; }
    public string IcdCode { get; set; } // Por ejemplo, "77176002" para tabaquismo en SNOMED CT

    // Description of the risk factor
    public string Description { get; set; }

    // Category of the risk factor (lifestyle, genetic, environmental, etc.)
    public RiskFactorCategory Category { get; set; }

    // Assessment level of the risk factor (low, moderate, high)
    public RiskFactorAssessmentLevel AssessmentLevel { get; set; }
    public ICollection<PatientRiskFactor> PatientRiskFactors { get; set; }
}
