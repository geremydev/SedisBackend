namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Risk_Factor_Condition
{
    public class SavePatientRiskFactorDto
    {
        public Guid PatientId { get; set; }
        public Guid RiskFactorId { get; set; }
    }
}
