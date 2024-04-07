using SedisBackend.Core.Domain.Medical_Insurance;
using SedisBackend.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_Insurance
{
    public class SaveMedicationlCoverageDto
    {
        public int Id { get; set; }
        public int HealthInsuranceId { get; set; } // FK
        public string MedicationId { get; set; } // FK
        public string CoverageStatus { get; set; } // Usando el enum ConverageStatus
        public decimal CopayAmount { get; set; } // Porcentaje que el paciente paga por la medicina
        public decimal CoinsurancePercentage { get; set; } // Porcentaje de lo que cubre la aseguradora
        public string PriorAuthorizationRequired { get; set; } // Indicates if prior authorization is needed
    }
}
