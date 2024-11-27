using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Risk_Factor;

namespace SedisBackend.Core.Domain.Entities.Relations;

public class PatientRiskFactor 
{
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public Guid RiskFactorId { get; set; }
    public RiskFactor RiskFactor { get; set; }
    public DateTime? DiagnosisDate { get; set; }
    public string Status { get; set; }
    public Guid MedicalConsultationId { get; set; }
    public MedicalConsultation MedicalConsultation { get; set; }

}
