using SedisBackend.Core.Domain.Medical_Insurance;
using SedisBackend.Core.Domain.Products;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_Insurance
{
    public class BaseMedicationCoverageDto
    {
        public Guid Id { get; set; }
        public Guid HealthInsuranceId { get; set; } // FK
        public HealthInsurance HealthInsurance { get; set; }
        public Guid MedicationId { get; set; } // FK
        public Medication Medication { get; set; }
        public string CoverageStatus { get; set; } // Usando el enum ConverageStatus
        public decimal CopayAmount { get; set; } // Porcentaje que el paciente paga por la medicina
        public decimal CoinsurancePercentage { get; set; } // Porcentaje de lo que cubre la aseguradora
        public string PriorAuthorizationRequired { get; set; } // Indicates if prior authorization is needed
    }
}
