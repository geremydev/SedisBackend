namespace SedisBackend.Core.Domain.DTO.Entities.Medical_Insurance.HealthInsuranceDTO;

public class HealthInsuranceDto
{
    public Guid Id { get; set; }
    public string InsuranceName { get; set; }
    public string PolicyType { get; set; } // Usando el enum PolicyType
    public string InsuranceCompany { get; set; }
    public string CoverageLevel { get; set; } // Usando el enum CoverageLevel
}
