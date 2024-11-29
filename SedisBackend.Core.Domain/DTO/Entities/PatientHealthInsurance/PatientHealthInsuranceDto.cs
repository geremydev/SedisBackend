namespace SedisBackend.Core.Domain.DTO.Entities.PatientHealthInsurance;
public class PatientHealthInsuranceDto
{
    public string PolicyNumber { get; set; } //Numero de Poliza
    public Guid PatientId { get; set; }
    public Guid HealthInsuranceId { get; set; }
    public bool Status { get; set; }
}
