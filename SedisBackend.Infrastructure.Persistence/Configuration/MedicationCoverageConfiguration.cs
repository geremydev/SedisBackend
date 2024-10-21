using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Enums;
using SedisBackend.Core.Domain.Medical_Insurance;

namespace SedisBackend.Infrastructure.Persistence.Configuration;

public class MedicationCoverageConfiguration : IEntityTypeConfiguration<MedicationCoverage>
{
    public void Configure(EntityTypeBuilder<MedicationCoverage> builder)
    {
        builder.HasData
        (
            new MedicationCoverage
            {
                Id = Guid.Parse("6e3245b7-6f76-411a-93a1-2c2a4793e12e"),
                HealthInsuranceId = Guid.Parse("b51ec3f9-bdc8-4a74-b43e-bf4da6e2f9b9"),
                MedicationId = Guid.Parse("a2d1c5b7-8f4e-4a6b-9c3d-5e7a1b2c9f5d"),
                CoverageStatus = CoverageStatus.Covered,
                CopayAmount = 50m,
                CoinsurancePercentage = 80m,
                PriorAuthorizationRequired = true
            },
            new MedicationCoverage
            {
                Id = Guid.Parse("4e3e5c9f-1db4-47a4-a853-4e5b3c4f9a1d"),
                HealthInsuranceId = Guid.Parse("7f5d5339-9de6-4ab0-b43c-d6b3d43e4d80"),
                MedicationId = Guid.Parse("e6b5a3c7-9d4f-4a8b-7e1c-2d9f1a5b3c6d"),
                CoverageStatus = CoverageStatus.PartiallyCovered,
                CopayAmount = 30m,
                CoinsurancePercentage = 70m,
                PriorAuthorizationRequired = false
            }
        );
    }
}
