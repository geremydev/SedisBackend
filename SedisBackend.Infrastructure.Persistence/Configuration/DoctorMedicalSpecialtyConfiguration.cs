using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Users.Doctors;

namespace SedisBackend.Infrastructure.Persistence.Configuration
{
    public class DoctorMedicalSpecialtyConfiguration : IEntityTypeConfiguration<DoctorMedicalSpecialty>
    {
        public void Configure(EntityTypeBuilder<DoctorMedicalSpecialty> builder)
        {
            builder.ToTable("DoctorMedicalSpecialties");

            builder.HasData
            (
                new DoctorMedicalSpecialty
                {
                    Id = Guid.NewGuid(),
                    DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), // Doctor John Doe
                    MedicalSpecialtyId = Guid.Parse("f1a2b3c4-d5e6-789f-0123-456789abcdef") // Example ID for specialty
                },
                new DoctorMedicalSpecialty
                {
                    Id = Guid.NewGuid(),
                    DoctorId = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), // Doctor Jane Smith
                    MedicalSpecialtyId = Guid.Parse("a1b2c3d4-e5f6-7890-1234-56789abcdef0") // Example ID for specialty
                }
            );
        }
    }
}
