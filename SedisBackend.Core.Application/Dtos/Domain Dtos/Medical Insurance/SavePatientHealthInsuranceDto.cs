namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_Insurance
{
    public class SavePatientHealthInsuranceDto
    {
        public string PolicyNumber { get; set; } //Numero de Poliza
        public Guid PatientId { get; set; }
        public Guid HealthInsuranceId { get; set; }
    }
}

