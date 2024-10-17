using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Prescriptions;

namespace SedisBackend.Infrastructure.Persistence.Configuration
{
    public class LabTestPrescriptionConfiguration : IEntityTypeConfiguration<LabTestPrescription>
    {
        public void Configure(EntityTypeBuilder<LabTestPrescription> builder)
        {
            builder.HasData
            (
                new LabTestPrescription
                {
                    Id = Guid.Parse("f2d5c7a1-3e4b-8f9d-1a2c-6b3e5d9f4c7a"),
                    ClinicalHistoryId = Guid.Parse("c1aaea0c-c739-4125-a7b3-28da602de5a0"),
                    LabTestId = Guid.Parse("9d2a5e4c-8b3f-4a7d-9c5b-3f2e1b6a7d9c"),
                    PrescriptionId = Guid.Parse("3a5d9b2e-8c4a-4f7e-9d1c-3f6b2a7d8e9c"),
                    Status = "Pending",
                    PerformedDate = DateTime.Parse("2023-06-15"),
                    ResultUrl = "http://example.com/results1.pdf"
                },
                new LabTestPrescription
                {
                    Id = Guid.Parse("b8a5d3f2-4e9a-6b7c-1d2f-5c9e3a7d4f8b"),
                    ClinicalHistoryId = Guid.Parse("47d713da-eb0f-44c8-bd0d-d1882834c81b"),
                    LabTestId = Guid.Parse("2b5d9a1c-4e7f-3a8c-6b9d-5f2a3e4b1f7a"),
                    PrescriptionId = Guid.Parse("2d7a9b5c-1e3a-4b8c-9f7e-5b3d6a1c9e7b"),
                    Status = "Done",
                    PerformedDate = DateTime.Parse("2024-02-12"),
                    ResultUrl = "http://example.com/results2.pdf"
                }
            );
        }
    }
}
