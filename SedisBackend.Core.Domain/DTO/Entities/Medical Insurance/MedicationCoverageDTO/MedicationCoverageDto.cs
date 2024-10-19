﻿using SedisBackend.Core.Domain.Entities.Models.Products;
using SedisBackend.Core.Domain.Medical_Insurance;

namespace SedisBackend.Core.Domain.DTO.Entities.Medical_Insurance.MedicationCoverageDTO;

public record MedicationCoverageDto
{
    public Guid Id { get; set; }
    public Guid HealthInsuranceId { get; set; } // FK
    public HealthInsurance HealthInsurance { get; set; }
    public Guid MedicationId { get; set; } // FK
    public Medication Medication { get; set; }
    public string CoverageStatus { get; set; } // Usando el enum ConverageStatus
    public decimal CopayAmount { get; set; } // Porcentaje que el paciente paga por la medicina
    public decimal CoinsurancePercentage { get; set; } // Porcentaje de lo que cubre la aseguradora
    public bool PriorAuthorizationRequired { get; set; } // Indicates if prior authorization is needed
}
