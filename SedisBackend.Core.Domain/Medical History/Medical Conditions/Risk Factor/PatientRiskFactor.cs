using SedisBackend.Core.Domain.Users.Patients;

namespace SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Risk_Factor
{
    public class PatientRiskFactor : IBaseEntity
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public Guid RiskFactorId { get; set; }
        public RiskFactor RiskFactor { get; set; }
    }
}
