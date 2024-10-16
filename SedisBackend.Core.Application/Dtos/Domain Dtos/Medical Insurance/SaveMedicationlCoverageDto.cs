namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_Insurance
{
    public class SaveMedicationlCoverageDto
    {
        public Guid Id { get; set; }
        public Guid HealthInsuranceId { get; set; } // FK
        public Guid MedicationId { get; set; } // FK
        public string CoverageStatus { get; set; } // Usando el enum ConverageStatus
        public decimal CopayAmount { get; set; } // Porcentaje que el paciente paga por la medicina
        public decimal CoinsurancePercentage { get; set; } // Porcentaje de lo que cubre la aseguradora
        public string PriorAuthorizationRequired { get; set; } // Indicates if prior authorization is needed
    }
}
