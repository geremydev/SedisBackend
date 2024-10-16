using SedisBackend.Core.Domain.Medical_Insurance;
using SedisBackend.Core.Domain.Users.Patients;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_Insurance
{
    public class BasePatientHealthInsuranceDto
    {
        public Guid Id { get; set; }
        public string PolicyNumber { get; set; } //Numero de Poliza
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public Guid HealthInsuranceId { get; set; }
        public HealthInsurance HealthInsurance { get; set; }
    }

}
