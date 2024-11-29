using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Infrastructure.Persistence.Configurations.RelationsConfigurations;

public class PatientVaccineConfiguration : IEntityTypeConfiguration<PatientVaccine>
{
    public void Configure(EntityTypeBuilder<PatientVaccine> builder)
    {
        builder.HasData
        (
            new PatientVaccine
            {
                PatientId = Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"),
                VaccineId = Guid.Parse("308c146a-7b3e-4426-b394-971aad7e50bb"),
                AppliedDoses = 2,
                LastApplicationDate = DateTime.Parse("2021-03-10"),
                Status = true,
            },
            new PatientVaccine
            {
                PatientId = Guid.Parse("e2a4d5b6-3c9a-47bc-8db1-cd327a2f92d6"),
                VaccineId = Guid.Parse("04561950-934c-47d9-a4df-55daa2143135"),
                AppliedDoses = 1,
                LastApplicationDate = DateTime.Parse("2023-09-15"),
                Status = true,
            },
            new PatientVaccine
            {
                PatientId = Guid.Parse("b7e1e44d-72c9-4c91-a933-9e4f0e6b5f11"),
                VaccineId = Guid.Parse("9c7bed88-e92c-459d-8a50-2fd9041c2c26"),
                AppliedDoses = 3,
                LastApplicationDate = DateTime.Parse("2022-07-20"),
                Status = true,
            },
            new PatientVaccine
            {
                PatientId = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
                VaccineId = Guid.Parse("ff079100-01b3-4902-86b0-64083d72c6fe"),
                AppliedDoses = 2,
                LastApplicationDate = DateTime.Parse("2020-10-15"),
                Status = true,
            },
            new PatientVaccine
            {
                PatientId = Guid.Parse("ea48eb4c-01c4-44d2-a81f-fc9246d2ec20"),
                VaccineId = Guid.Parse("d8d4c92b-a7d9-4205-8524-829ef5ca97d7"),
                AppliedDoses = 2,
                LastApplicationDate = DateTime.Parse("2021-12-05"),
                Status = true,
            }
        );
    }
}
