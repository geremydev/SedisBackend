using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Infrastructure.Persistence.Configurations.RelationsConfigurations;

public class PatientHealthInsuranceConfiguration : IEntityTypeConfiguration<PatientHealthInsurance>
{
    public void Configure(EntityTypeBuilder<PatientHealthInsurance> builder)
    {
        builder.HasData
        (
            new PatientHealthInsurance
            {
                PolicyNumber = "P0123456789",
                PatientId = Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"),
                HealthInsuranceId = Guid.Parse("b51ec3f9-bdc8-4a74-b43e-bf4da6e2f9b9"),
                Status = true
            },
            new PatientHealthInsurance
            {
                PolicyNumber = "P0987654321",
                PatientId = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
                HealthInsuranceId = Guid.Parse("7f5d5339-9de6-4ab0-b43c-d6b3d43e4d80"),
                Status = true
            },
            new PatientHealthInsurance
            {
                PolicyNumber = "P1234567890",
                PatientId = Guid.Parse("ea48eb4c-01c4-44d2-a81f-fc9246d2ec20"),
                HealthInsuranceId = Guid.Parse("b51ec3f9-bdc8-4a74-b43e-bf4da6e2f9b9"),
                Status = true
            },
            new PatientHealthInsurance
            {
                PolicyNumber = "P2345678901",
                PatientId = Guid.Parse("f86a1609-cb84-4d6a-8d8a-8e49b6b9a5b9"),
                HealthInsuranceId = Guid.Parse("7f5d5339-9de6-4ab0-b43c-d6b3d43e4d80"),
                Status = true
            },
            new PatientHealthInsurance
            {
                PolicyNumber = "P3456789012",
                PatientId = Guid.Parse("37439d05-9b3b-4896-88e0-4ee7b7221a8b"),
                HealthInsuranceId = Guid.Parse("b51ec3f9-bdc8-4a74-b43e-bf4da6e2f9b9"),
                Status = true
            },
            new PatientHealthInsurance
            {
                PolicyNumber = "P4567890123",
                PatientId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                HealthInsuranceId = Guid.Parse("7f5d5339-9de6-4ab0-b43c-d6b3d43e4d80"),
                Status = true
            },
            new PatientHealthInsurance
            {
                PolicyNumber = "P5678901234",
                PatientId = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"),
                HealthInsuranceId = Guid.Parse("b51ec3f9-bdc8-4a74-b43e-bf4da6e2f9b9"),
                Status = true
            },
            new PatientHealthInsurance
            {
                PolicyNumber = "P6789012345",
                PatientId = Guid.Parse("83d48d7c-6a56-4233-9934-9d30bde63bb5"),
                HealthInsuranceId = Guid.Parse("7f5d5339-9de6-4ab0-b43c-d6b3d43e4d80"),
                Status = true
            },
            new PatientHealthInsurance
            {
                PolicyNumber = "P7890123456",
                PatientId = Guid.Parse("9c87b12f-d892-4f2b-8e2c-5347c8c1b056"),
                HealthInsuranceId = Guid.Parse("b51ec3f9-bdc8-4a74-b43e-bf4da6e2f9b9"),
                Status = true
            },
            new PatientHealthInsurance
            {
                PolicyNumber = "P8901234567",
                PatientId = Guid.Parse("b7e1e44d-72c9-4c91-a933-9e4f0e6b5f11"),
                HealthInsuranceId = Guid.Parse("7f5d5339-9de6-4ab0-b43c-d6b3d43e4d80"),
                Status = true
            },
            new PatientHealthInsurance
            {
                PolicyNumber = "P9012345678",
                PatientId = Guid.Parse("e2a4d5b6-3c9a-47bc-8db1-cd327a2f92d6"),
                HealthInsuranceId = Guid.Parse("b51ec3f9-bdc8-4a74-b43e-bf4da6e2f9b9"),
                Status = true
            }
        );
    }
}
