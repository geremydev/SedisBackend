using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Risk_Factor;

namespace SedisBackend.Infrastructure.Persistence.Configuration
{
    public class PatientRiskFactorConfiguration : IEntityTypeConfiguration<PatientRiskFactor>
    {
        public void Configure(EntityTypeBuilder<PatientRiskFactor> builder)
        {
            builder.HasData
            (
                new PatientRiskFactor
                {
                    Id = Guid.Parse("f68f3e15-994e-4c2d-a3ee-863d753032b0"),
                    PatientId = Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"),
                    RiskFactorId = Guid.Parse("454e8d39-1363-41f4-a2d2-b99fde743fbf")
                },
                new PatientRiskFactor
                {
                    Id = Guid.Parse("807afcdf-633e-44a9-b688-4f3dd50ab905"),
                    PatientId = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
                    RiskFactorId = Guid.Parse("6522252f-0021-433b-8174-f4e0833f859a")
                }
            );
        }
    }
}
