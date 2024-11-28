using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Medical_Insurance;

namespace SedisBackend.Core.Domain.DTO.Entities.PatientHealthInsurance;
public class PatientHealthInsuranceDto
{
    public string PolicyNumber { get; set; } //Numero de Poliza
    public Guid PatientId { get; set; }
    public Guid HealthInsuranceId { get; set; }
    public bool Status { get; set; }
}
