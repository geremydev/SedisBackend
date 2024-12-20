﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Infrastructure.Persistence.Configurations.RelationsConfigurations;

public class MedicationCoverageConfiguration : IEntityTypeConfiguration<MedicationCoverage>
{
    public void Configure(EntityTypeBuilder<MedicationCoverage> builder)
    {
        builder.HasData
        (
            new MedicationCoverage
            {
                HealthInsuranceId = Guid.Parse("b51ec3f9-bdc8-4a74-b43e-bf4da6e2f9b9"),
                MedicationId = Guid.Parse("a2d1c5b7-8f4e-4a6b-9c3d-5e7a1b2c9f5d"),
                CopayAmount = 50m,
                CoinsurancePercentage = 80m,
                PriorAuthorizationRequired = true,
                Status = true,
            },
            new MedicationCoverage
            {
                HealthInsuranceId = Guid.Parse("7f5d5339-9de6-4ab0-b43c-d6b3d43e4d80"),
                MedicationId = Guid.Parse("e6b5a3c7-9d4f-4a8b-7e1c-2d9f1a5b3c6d"),
                CopayAmount = 70m,
                CoinsurancePercentage = 90m,
                PriorAuthorizationRequired = false,
                Status = true,
            },
            new MedicationCoverage
            {
                HealthInsuranceId = Guid.Parse("b51ec3f9-bdc8-4a74-b43e-bf4da6e2f9b9"),
                MedicationId = Guid.Parse("c3f4a6b7-8d1e-4b9c-2e7a-1c5b3d6f9e7a"),
                CopayAmount = 20m,
                CoinsurancePercentage = 40m,
                PriorAuthorizationRequired = false,
                Status = true,
            },
            new MedicationCoverage
            {
                HealthInsuranceId = Guid.Parse("7f5d5339-9de6-4ab0-b43c-d6b3d43e4d80"),
                MedicationId = Guid.Parse("f6b9a1c5-2e7a-3d6f-8d1e-4b3c7f9e7a1c"),
                CopayAmount = 30m,
                CoinsurancePercentage = 60m,
                PriorAuthorizationRequired = true,
                Status = true,
            },
            new MedicationCoverage
            {
                HealthInsuranceId = Guid.Parse("b51ec3f9-bdc8-4a74-b43e-bf4da6e2f9b9"),
                MedicationId = Guid.Parse("d7e1c5b3-8f4a-4b6c-9f9e-2a7a1d6f8e9a"),
                CopayAmount = 10m,
                CoinsurancePercentage = 50m,
                PriorAuthorizationRequired = false,
                Status = true,
            }
        );
    }
}
