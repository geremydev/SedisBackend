using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Medical_Insurance;

namespace SedisBackend.Core.Domain.Entities.Relations;

public class PatientHealthInsurance : IBaseEntity
{
    public Guid Id { get; set; }
    public string PolicyNumber { get; set; } //Numero de Poliza
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public Guid HealthInsuranceId { get; set; }
    public HealthInsurance HealthInsurance { get; set; }
}
