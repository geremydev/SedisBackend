using SedisBackend.Core.Domain.Enums;

namespace SedisBackend.Core.Domain.DTO.Entities.Medical_Insurance.HealthInsuranceDTO;

public record HealthInsuranceForCreationDto
{
    public string InsuranceName { get; set; }
    public PolicyType PolicyType { get; set; }
    public string InsuranceCompany { get; set; }
    public CoverageLevel CoverageLevel { get; set; }
}
