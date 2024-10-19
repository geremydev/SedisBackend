using SedisBackend.Core.Domain.Enums;

namespace SedisBackend.Core.Domain.DTO.Entities.Medical_Insurance.MedicationCoverageDTO;

public record MedicationCoverageForCreationDto
{
    public Guid HealthInsuranceId { get; set; }
    public Guid MedicationId { get; set; }
    public CoverageStatus CoverageStatus { get; set; }
    public decimal CopayAmount { get; set; }
    public decimal CoinsurancePercentage { get; set; }
    public bool PriorAuthorizationRequired { get; set; }
}
