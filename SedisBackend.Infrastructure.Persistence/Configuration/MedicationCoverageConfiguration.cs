using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Enums;

namespace SedisBackend.Infrastructure.Persistence.Configuration;

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
                Status = true,
                CopayAmount = 50m,
                CoinsurancePercentage = 80m,
                PriorAuthorizationRequired = true
            },
            new MedicationCoverage
            {
                HealthInsuranceId = Guid.Parse("7f5d5339-9de6-4ab0-b43c-d6b3d43e4d80"),
                MedicationId = Guid.Parse("e6b5a3c7-9d4f-4a8b-7e1c-2d9f1a5b3c6d"),
                Status = true,
                CopayAmount = 30m,
                CoinsurancePercentage = 70m,
                PriorAuthorizationRequired = false
            }
        );
    }
}
