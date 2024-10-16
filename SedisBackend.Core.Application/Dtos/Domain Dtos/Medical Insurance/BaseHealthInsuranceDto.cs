using SedisBackend.Core.Domain.Medical_Insurance;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_Insurance
{
    public class BaseHealthInsuranceDto
    {
        public Guid Id { get; set; }
        public string InsuranceName { get; set; }
        public string PolicyType { get; set; } // Usando el enum PolicyType
        public string InsuranceCompany { get; set; }
        public string CoverageLevel { get; set; } // Usando el enum CoverageLevel
        public List<MedicationCoverage> MedicationCoverages { get; set; }
        public List<PatientHealthInsurance> SubscribedPatients { get; set; }
    }
}
