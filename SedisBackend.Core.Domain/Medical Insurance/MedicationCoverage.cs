using SedisBackend.Core.Domain.Products;

namespace SedisBackend.Core.Domain.Medical_Insurance
{
    public class MedicationCoverage
    {
        public int Id { get; set; }
        public string HealthInsuranceId { get; set; } // FK
        public HealthInsurance HealthInsurance { get; set; } 
        public string MedicationId { get; set; } // FK
        public Medication Medication { get; set; }
        public string  CoverageStatus { get; set; } // Usando el enum ConverageStatus
        public decimal CopayAmount { get; set; } // Porcentaje que el paciente paga por la medicina
        public decimal CoinsurancePercentage { get; set; } // Porcentaje de lo que cubre la aseguradora
        public string PriorAuthorizationRequired { get; set; } // Indicates if prior authorization is needed
    }

}
