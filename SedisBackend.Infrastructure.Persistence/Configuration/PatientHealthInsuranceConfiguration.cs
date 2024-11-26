using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Infrastructure.Persistence.Configuration;

public class PatientHealthInsuranceConfiguration : IEntityTypeConfiguration<PatientHealthInsurance>
{
    public void Configure(EntityTypeBuilder<PatientHealthInsurance> builder)
    {
        builder.HasData
        (
            new PatientHealthInsurance
            {
                PolicyNumber = "P0123456789",
                PatientId = Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), // Example Patient ID
                HealthInsuranceId = Guid.Parse("b51ec3f9-bdc8-4a74-b43e-bf4da6e2f9b9"), // Example Insurance ID
                Status = true
            },
            new PatientHealthInsurance
            {
                PolicyNumber = "P0987654321",
                PatientId = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), // Example Patient ID
                HealthInsuranceId = Guid.Parse("7f5d5339-9de6-4ab0-b43c-d6b3d43e4d80"), // Example Insurance ID
                Status = true
            }
        );
    }
}
