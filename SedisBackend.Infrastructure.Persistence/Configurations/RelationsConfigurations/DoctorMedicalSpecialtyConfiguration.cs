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
                Id = Guid.Parse("90daa116-fb31-4781-ae3e-794dd0c53eb3"),
                DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                MedicalSpecialtyId = Guid.Parse("b1c2d3e4-f5a6-6789-0123-abcdef456789")
            },
            new DoctorMedicalSpecialty
            {
                Id = Guid.Parse("29c06383-6255-46b4-ba35-7539c7c105d8"),
                DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                MedicalSpecialtyId = Guid.Parse("c2d3e4f5-a6b7-8901-2345-abcdef678901")
            },
            new DoctorMedicalSpecialty
            {
                Id = Guid.Parse("df29e860-f3c8-4f99-9d30-dfd18150abcd"),
                DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                MedicalSpecialtyId = Guid.Parse("d3e4f5a6-b7c8-9012-3456-abcdef789012")
            },

            new DoctorMedicalSpecialty
            {
                Id = Guid.Parse("5d5f5a7c-433b-4d3b-a463-9fd8f2330e97"),
                DoctorId = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"),
                MedicalSpecialtyId = Guid.Parse("d3e4f5a6-b7c8-9012-3456-abcdef789012")
            },

            new DoctorMedicalSpecialty
            {
                Id = Guid.Parse("7a40e2e2-b195-403e-8c5e-018ea9cbb8ff"),
                DoctorId = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"),
                MedicalSpecialtyId = Guid.Parse("e4f5a6b7-c8d9-0123-4567-abcdef890123")
            },
            new DoctorMedicalSpecialty
            {
                Id = Guid.Parse("ff3cf3f5-6ef5-4163-8efa-3bcbc48dc870"),
                DoctorId = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"),
                MedicalSpecialtyId = Guid.Parse("f5a6b7c8-d9e0-1234-5678-abcdef901234")
            },
            new DoctorMedicalSpecialty
            {
                Id = Guid.Parse("28fe0d97-e301-42d1-bd01-61443d8a4961"),
                DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                MedicalSpecialtyId = Guid.Parse("a6b7c8d9-e0f1-2345-6789-abcdef012345")
            },
            new DoctorMedicalSpecialty
            {
                Id = Guid.Parse("31fbd177-1112-48b1-8213-c838151fc8c2"),
                DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                MedicalSpecialtyId = Guid.Parse("b7c8d9e0-f1a2-3456-7890-abcdef123456")
            },
            new DoctorMedicalSpecialty
            {
                Id = Guid.Parse("28a7f19f-dafb-4406-b6b4-c3406d933aa5"),
                DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                MedicalSpecialtyId = Guid.Parse("c8d9e0f1-a2b3-4567-8901-abcdef234567")
            },
            new DoctorMedicalSpecialty
            {
                Id = Guid.Parse("30cf9635-b63c-46f7-a27e-3b885329a6d7"),
                DoctorId = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"),
                MedicalSpecialtyId = Guid.Parse("d9e0f1a2-b3c4-5678-9012-abcdef345678")
            },
            new DoctorMedicalSpecialty
            {
                Id = Guid.Parse("17fd5c35-a5bb-44e4-add5-06c0b09edf75"),
                DoctorId = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"),
                MedicalSpecialtyId = Guid.Parse("e0f1a2b3-c4d5-6789-0123-abcdef456789")
            }
        );
    }
}
