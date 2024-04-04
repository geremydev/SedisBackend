using SedisBackend.Core.Domain.Users.Patients;

namespace SedisBackend.Core.Domain.Medical_Insurance
{
    public class HealthInsurance
    {
        public int Id { get; set; }
        public string PolicyNumber { get; set; } 
        public string PatientId { get; set; }
        public Patient Patient { get; set; }
        public string InsuranceName { get; set; }
        public string PolicyType { get; set; } // Usando el enum PolicyType
        public string InsuranceCompany { get; set; }
        public string CoverageLevel { get; set; } // Usando el enum CoverageLevel

        public List<MedicationCoverage> MedicationCoverages { get; set; } = new List<MedicationCoverage>();

    }
}
