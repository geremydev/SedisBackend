using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Discapacity_Condition;

namespace SedisBackend.Infrastructure.Persistence.Configuration
{
    public class PatientDiscapacityConfiguration : IEntityTypeConfiguration<PatientDiscapacity>
    {
        public void Configure(EntityTypeBuilder<PatientDiscapacity> builder)
        {
            builder.HasData
            (
                new PatientDiscapacity
                {
                    Id = Guid.Parse("ae6aa623-f515-4b49-a926-5e72369cce77"),
                    PatientId = Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"),
                    DiscapacityId = Guid.Parse("1b54e13f-7a32-4cc1-ad6d-35298426a2fb"),
                    DiagnosisDate = DateTime.Parse("2018-05-15"),
                    Severity = "Severa"
                },
                new PatientDiscapacity
                {
                    Id = Guid.Parse("79dad0d7-f852-486c-a369-9765aafefa86"),
                    PatientId = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
                    DiscapacityId = Guid.Parse("5c52a9d3-6ee2-496e-a922-139de857d9d4"),
                    DiagnosisDate = DateTime.Parse("2020-11-20"),
                    Severity = "Moderada"
                }
            );
        }
    }
}
