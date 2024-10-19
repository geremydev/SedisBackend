using SedisBackend.Core.Domain.DTO.Entities.Users.Patients;
using SedisBackend.Core.Domain.Enums;
using SedisBackend.Core.Domain.Medical_Insurance;

namespace SedisBackend.Core.Domain.DTO.Entities.Medical_Insurance.HealthInsuranceDTO;

public record HealthInsuranceDto
{
    public Guid Id { get; set; }
    public string InsuranceName { get; set; }
    public PolicyType PolicyType { get; set; } // Usando el enum PolicyType
    public string InsuranceCompany { get; set; }
    public CoverageLevel CoverageLevel { get; set; } // Usando el enum CoverageLevel
    public ICollection<MedicationCoverage> MedicationCoverages { get; set; }
    public ICollection<PatientDto> SubscribedPatients { get; set; }
}
