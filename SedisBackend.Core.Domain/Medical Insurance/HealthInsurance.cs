using SedisBackend.Core.Domain.Users.Patients;

namespace SedisBackend.Core.Domain.Medical_Insurance
{
    public class HealthInsurance
    {
        public Guid Id { get; set; }
        public string InsuranceName { get; set; }
        public string PolicyType { get; set; } // Usando el enum PolicyType
        public string InsuranceCompany { get; set; }
        public string CoverageLevel { get; set; } // Usando el enum CoverageLevel
        public ICollection<MedicationCoverage> MedicationCoverages { get; set; }
        public ICollection<PatientHealthInsurance> SubscribedPatients { get; set; }

    }
}
