namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Risk_Factor_Condition
{
    public class BaseRiskFactorDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; } //SNOMED CT

        // Description of the risk factor
        public string Description { get; set; }

        // Category of the risk factor (lifestyle, genetic, environmental, etc.)
        public string Category { get; set; }

        // Assessment level of the risk factor (low, moderate, high)
        public string AssessmentLevel { get; set; }
    }
}
