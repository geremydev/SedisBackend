using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Infrastructure.Persistence.Configurations.RelationsConfigurations;

public class DoctorMedicalSpecialtyConfiguration : IEntityTypeConfiguration<DoctorMedicalSpecialty>
{
    public void Configure(EntityTypeBuilder<DoctorMedicalSpecialty> builder)
    {
        builder.ToTable("DoctorMedicalSpecialties");

        builder.HasData
        (
            new DoctorMedicalSpecialty
            {
                DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                MedicalSpecialtyId = Guid.Parse("b1c2d3e4-f5a6-6789-0123-abcdef456789")
            },
            new DoctorMedicalSpecialty
            {
                DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                MedicalSpecialtyId = Guid.Parse("c2d3e4f5-a6b7-8901-2345-abcdef678901")
            },
            new DoctorMedicalSpecialty
            {
                DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                MedicalSpecialtyId = Guid.Parse("d3e4f5a6-b7c8-9012-3456-abcdef789012")
            },

            new DoctorMedicalSpecialty
            {
                DoctorId = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"),
                MedicalSpecialtyId = Guid.Parse("d3e4f5a6-b7c8-9012-3456-abcdef789012")
            },

            new DoctorMedicalSpecialty
            {
                DoctorId = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"),
                MedicalSpecialtyId = Guid.Parse("e4f5a6b7-c8d9-0123-4567-abcdef890123")
            },
            new DoctorMedicalSpecialty
            {
                DoctorId = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"),
                MedicalSpecialtyId = Guid.Parse("f5a6b7c8-d9e0-1234-5678-abcdef901234")
            },
            new DoctorMedicalSpecialty
            {
                DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                MedicalSpecialtyId = Guid.Parse("a6b7c8d9-e0f1-2345-6789-abcdef012345")
            },
            new DoctorMedicalSpecialty
            {
                DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                MedicalSpecialtyId = Guid.Parse("b7c8d9e0-f1a2-3456-7890-abcdef123456")
            },
            new DoctorMedicalSpecialty
            {
                DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                MedicalSpecialtyId = Guid.Parse("c8d9e0f1-a2b3-4567-8901-abcdef234567")
            },
            new DoctorMedicalSpecialty
            {
                DoctorId = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"),
                MedicalSpecialtyId = Guid.Parse("d9e0f1a2-b3c4-5678-9012-abcdef345678")
            },
            new DoctorMedicalSpecialty
            {
                DoctorId = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"),
                MedicalSpecialtyId = Guid.Parse("e0f1a2b3-c4d5-6789-0123-abcdef456789")
            }
        );
    }
}
