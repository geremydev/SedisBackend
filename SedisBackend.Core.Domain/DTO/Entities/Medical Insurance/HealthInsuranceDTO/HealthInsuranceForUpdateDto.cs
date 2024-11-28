namespace SedisBackend.Core.Domain.DTO.Entities.Medical_Insurance.HealthInsuranceDTO;

public record HealthInsuranceForUpdateDto
{
    public string InsuranceName { get; set; }
    public string PolicyType { get; set; }
    public string InsuranceCompany { get; set; }
    public string CoverageLevel { get; set; }
    public HealthInsuranceForUpdateDto() { }
}
