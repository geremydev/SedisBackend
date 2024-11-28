﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Risk_Factor;

namespace SedisBackend.Infrastructure.Persistence.Configurations.DomainConfigurations;

public class RiskFactorConfiguration : IEntityTypeConfiguration<RiskFactor>
{
    public void Configure(EntityTypeBuilder<RiskFactor> builder)
    {
        builder.HasData
        (
            new RiskFactor
            {
                Id = Guid.Parse("a34f2c12-d4b6-42e9-8f7a-9012c3e4f567"),
                IcdCode = "I250",
                Description = "Tabaquismo activo",
                PatientRiskFactors = new List<PatientRiskFactor>()
            },
            new RiskFactor
            {
                Id = Guid.Parse("b78f3e45-c5d6-47e1-a9f8-3456d7e8f901"),
                IcdCode = "E669",
                Description = "Obesidad",
                PatientRiskFactors = new List<PatientRiskFactor>()
            },
            new RiskFactor
            {
                Id = Guid.Parse("c98f4e56-d7f8-489a-b9e1-4567e8f9a012"),
                IcdCode = "F102",
                Description = "Consumo de drogas",
                PatientRiskFactors = new List<PatientRiskFactor>()
            },
            new RiskFactor
            {
                Id = Guid.Parse("d12f5e67-e9f0-4a9b-c8f2-5678f9a0b123"),
                IcdCode = "K746",
                Description = "Cirrosis hepática",
                PatientRiskFactors = new List<PatientRiskFactor>()
            },
            new RiskFactor
            {
                Id = Guid.Parse("e23f6e78-f1f2-4b0c-d9f3-6789a0b1c234"),
                IcdCode = "Z720",
                Description = "Sedentarismo",
                PatientRiskFactors = new List<PatientRiskFactor>()
            },
            new RiskFactor
            {
                Id = Guid.Parse("f45f7e89-a1c2-4b5d-bcde-67890a1b2345"),
                IcdCode = "H522",
                Description = "Uso prolongado de lentes de contacto",
                PatientRiskFactors = new List<PatientRiskFactor>()
            }
        );
    }
}
