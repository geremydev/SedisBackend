using SedisBackend.Core.Domain.Entities.Models.Products;
using SedisBackend.Core.Domain.Medical_Insurance;

namespace SedisBackend.Core.Domain.Entities.Relations;

public class MedicationCoverage
{
    public Guid HealthInsuranceId { get; set; } // FK
    public HealthInsurance HealthInsurance { get; set; }
    public Guid MedicationId { get; set; } // FK
    public Medication Medication { get; set; }
    public decimal CopayAmount { get; set; } // Porcentaje que el paciente paga por la medicina
    public decimal CoinsurancePercentage { get; set; } // Porcentaje de lo que cubre la aseguradora
    public bool PriorAuthorizationRequired { get; set; } // Indicates if prior authorization is needed
    public bool Status { get; set; }
}
