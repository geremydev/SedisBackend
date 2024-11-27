using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Infrastructure.Persistence.Configuration;

public class PatientLabTestPrescriptionConfiguration : IEntityTypeConfiguration<PatientLabTestPrescription>
{
    public void Configure(EntityTypeBuilder<PatientLabTestPrescription> builder)
    {
        builder.HasData
        (
            new PatientLabTestPrescription
            {
                Id = Guid.Parse("f2d5c7a1-3e4b-8f9d-1a2c-6b3e5d9f4c7a"),
                MedicalConsultationId = Guid.Parse("c1aaea0c-c739-4125-a7b3-28da602de5a0"),
                
                Status = "Pending",
                PerformedDate = DateTime.Parse("2023-06-15"),
                ResultUrl = "http://example.com/results1.pdf"
            },
            new PatientLabTestPrescription
            {
                Id = Guid.Parse("b8a5d3f2-4e9a-6b7c-1d2f-5c9e3a7d4f8b"),
                MedicalConsultationId = Guid.Parse("47d713da-eb0f-44c8-bd0d-d1882834c81b"),
                
                Status = "Done",
                PerformedDate = DateTime.Parse("2024-02-12"),
                ResultUrl = "http://example.com/results2.pdf"
            }
        );
    }
}
