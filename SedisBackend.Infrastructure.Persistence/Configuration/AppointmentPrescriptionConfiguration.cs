using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Infrastructure.Persistence.Configuration;

public class AppointmentPrescriptionConfiguration : IEntityTypeConfiguration<AppointmentPrescription>
{
    public void Configure(EntityTypeBuilder<AppointmentPrescription> builder)
    {
        builder.HasData
        (
            new AppointmentPrescription
            {
                Id = Guid.Parse("f2d5c7a1-3e4b-8f9d-1a2c-6b3e5d9f4c7a"),
                ClinicalHistoryId = Guid.Parse("c1aaea0c-c739-4125-a7b3-28da602de5a0"),
                AppointmentId = Guid.Parse("826783f5-dd4f-419e-bb2f-4a8307c54b9b"),
                PrescriptionId = Guid.Parse("3a5d9b2e-8c4a-4f7e-9d1c-3f6b2a7d8e9c"),
                Status = "Pending",
                PerformedDate = DateTime.Parse("2023-06-15"),
                ResultUrl = "http://example.com/results1.pdf"
            },
            new AppointmentPrescription
            {
                Id = Guid.Parse("b8a5d3f2-4e9a-6b7c-1d2f-5c9e3a7d4f8b"),
                ClinicalHistoryId = Guid.Parse("47d713da-eb0f-44c8-bd0d-d1882834c81b"),
                AppointmentId = Guid.Parse("5f028eff-479b-43dc-9e1b-2e6839c794f8"),
                PrescriptionId = Guid.Parse("2d7a9b5c-1e3a-4b8c-9f7e-5b3d6a1c9e7b"),
                Status = "Done",
                PerformedDate = DateTime.Parse("2024-02-12"),
                ResultUrl = "http://example.com/results2.pdf"
            }
        );
    }
}
