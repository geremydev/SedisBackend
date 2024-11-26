using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Infrastructure.Persistence.Configuration;

public class PatientVaccineConfiguration : IEntityTypeConfiguration<PatientVaccine>
{
    public void Configure(EntityTypeBuilder<PatientVaccine> builder)
    {
        builder.HasData
        (
            new PatientVaccine
            {
                PatientId = Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"),
                VaccineId = Guid.Parse("c28e855d-2602-423f-a4d5-26954df029da"),
                AppliedDoses = 2,
                LastApplicationDate = DateTime.Parse("2021-03-10"),
                Status = true
            },
            new PatientVaccine
            {
                PatientId = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
                VaccineId = Guid.Parse("384e34fb-7d23-4123-a78e-13d7b0a91110"),
                AppliedDoses = 1,
                LastApplicationDate = DateTime.Parse("2023-09-15"),
                Status = true
            }
        );
    }
}
