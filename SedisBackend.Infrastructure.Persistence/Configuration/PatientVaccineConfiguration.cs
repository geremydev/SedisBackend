using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Medical_History.Vaccines;

namespace SedisBackend.Infrastructure.Persistence.Configuration
{
    public class PatientVaccineConfiguration : IEntityTypeConfiguration<PatientVaccine>
    {
        public void Configure(EntityTypeBuilder<PatientVaccine> builder)
        {
            builder.HasData
            (
                new PatientVaccine
                {
                    Id = Guid.Parse("12ae1c94-c70d-4379-8cca-e8405a814c6d"),
                    PatientId = Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"),
                    VaccineId = Guid.Parse("c28e855d-2602-423f-a4d5-26954df029da"),
                    AppliedDoses = 2,
                    LastApplicationDate = DateTime.Parse("2021-03-10")
                },
                new PatientVaccine
                {
                    Id = Guid.Parse("086dd520-144e-4afe-98aa-2bf09033048c"),
                    PatientId = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
                    VaccineId = Guid.Parse("384e34fb-7d23-4123-a78e-13d7b0a91110"),
                    AppliedDoses = 1,
                    LastApplicationDate = DateTime.Parse("2023-09-15")
                }
            );
        }
    }
}
