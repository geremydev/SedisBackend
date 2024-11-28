using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Medical_History.Vaccines;

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
                VaccineId = Guid.Parse("f34f7e89-f2f3-4c1d-e0f4-7890b1c2d345"),
                AppliedDoses = 2,
                LastApplicationDate = DateTime.Parse("2021-03-10"),
                Status = true,
                Patient = new Patient(),
                Vaccine = new Vaccine(),
            },
            new PatientVaccine
            {
                PatientId = Guid.Parse("e2a4d5b6-3c9a-47bc-8db1-cd327a2f92d6"),
                VaccineId = Guid.Parse("123f8e90-f3f4-4d2e-f1f5-8901c2d3e456"),
                AppliedDoses = 1,
                LastApplicationDate = DateTime.Parse("2023-09-15"),
                Status = true,
                Patient = new Patient(),
                Vaccine = new Vaccine(),
            },
            new PatientVaccine
            {
                PatientId = Guid.Parse("d9a832b8-123a-4c98-baba-6e2a32e94b9e"),
                VaccineId = Guid.Parse("234f9e01-f4f5-4e3f-f2f6-9012d3e4f567"),
                AppliedDoses = 3,
                LastApplicationDate = DateTime.Parse("2022-07-20"),
                Status = true,
                Patient = new Patient(),
                Vaccine = new Vaccine(),
            },
            new PatientVaccine
            {
                PatientId = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
                VaccineId = Guid.Parse("345f0e12-f5f6-4f4f-f3f7-a012e4f5g678"),
                AppliedDoses = 2,
                LastApplicationDate = DateTime.Parse("2020-10-15"),
                Status = true,
                Patient = new Patient(),
                Vaccine = new Vaccine(),
            },
            new PatientVaccine
            {
                PatientId = Guid.Parse("ea48eb4c-01c4-44d2-a81f-fc9246d2ec20"),
                VaccineId = Guid.Parse("456f1e23-f6f7-504f-f4f8-b123f5g6h789"),
                AppliedDoses = 2,
                LastApplicationDate = DateTime.Parse("2021-12-05"),
                Status = true,
                Patient = new Patient(),
                Vaccine = new Vaccine(),
            }
        );
    }
}
