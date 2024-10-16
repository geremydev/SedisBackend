using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;

namespace SedisBackend.Infrastructure.Persistence.Configuration
{
    public class ClinicalHistoryConfiguration : IEntityTypeConfiguration<ClinicalHistory>
    {
        public void Configure(EntityTypeBuilder<ClinicalHistory> builder)
        {
            builder.ToTable("ClinicalHistories");

            builder.HasData
            (
                new ClinicalHistory
                {
                    Id = Guid.NewGuid(),
                    PatientId = Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), // Example ID for patient
                    DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), // Doctor John Doe
                    ReasonForVisit = "Routine check-up",
                    CurrentHistory = "No significant issues.",
                    Diagnosis = "Hypertension",
                    RegisterDate = DateTime.Now
                },
                new ClinicalHistory
                {
                    Id = Guid.NewGuid(),
                    PatientId = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), // Example ID for patient
                    DoctorId = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), // Doctor Jane Smith
                    ReasonForVisit = "Follow-up on medication.",
                    CurrentHistory = "Feeling better.",
                    Diagnosis = "Diabetes",
                    RegisterDate = DateTime.Now
                }
            );
        }
    }
}
