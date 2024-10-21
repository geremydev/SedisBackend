namespace SedisBackend.Core.Domain.DTO.Entities.Medical_Insurance.MedicationCoverageDTO;

public record MedicationCoverageForUpdateDto
{
    public Guid HealthInsuranceId { get; set; }
    public Guid MedicationId { get; set; }
    public string CoverageStatus { get; set; }
    public decimal CopayAmount { get; set; }
    public decimal CoinsurancePercentage { get; set; }
    public bool PriorAuthorizationRequired { get; set; }
    public MedicationCoverageForUpdateDto()
    {

    }
}
