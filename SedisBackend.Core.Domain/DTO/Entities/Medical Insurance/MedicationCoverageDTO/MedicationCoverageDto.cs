using SedisBackend.Core.Domain.DTO.Entities.Products.Medication;

namespace SedisBackend.Core.Domain.DTO.Entities.Medical_Insurance.MedicationCoverageDTO;

public record MedicationCoverageDto
{
    public Guid Id { get; set; }
    public MedicationDto Medication { get; set; }
    public string CoverageStatus { get; set; } // Usando el enum ConverageStatus
    public decimal CopayAmount { get; set; } // Porcentaje que el paciente paga por la medicina
    public decimal CoinsurancePercentage { get; set; } // Porcentaje de lo que cubre la aseguradora
    public bool PriorAuthorizationRequired { get; set; } // Indicates if prior authorization is needed
}
