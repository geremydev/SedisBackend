using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Enums;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Risk_Factor;

namespace SedisBackend.Infrastructure.Persistence.Configuration;

public class RiskFactorConfiguration : IEntityTypeConfiguration<RiskFactor>
{
    public void Configure(EntityTypeBuilder<RiskFactor> builder)
    {
        builder.HasData
        (
            new RiskFactor
            {
                Id = Guid.Parse("454e8d39-1363-41f4-a2d2-b99fde743fbf"),
                IcdCode = "L123",
                Description = "Consumo excesivo de alcohol",
                Category = RiskFactorCategory.Lifestyle,
                AssessmentLevel = RiskFactorAssessmentLevel.High
            },
            new RiskFactor
            {
                Id = Guid.Parse("6522252f-0021-433b-8174-f4e0833f859a"),
                IcdCode = "G789",
                Description = "Historia familiar de diabetes",
                Category = RiskFactorCategory.Genetic,
                AssessmentLevel = RiskFactorAssessmentLevel.Moderate
            }
        );
    }
}
