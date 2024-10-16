using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Users.Doctors;

namespace SedisBackend.Infrastructure.Persistence.Configuration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasData
            (
                new Doctor
                {
                    Id = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                    FirstName = "John",
                    LastName = "Doe",
                    LicenseNumber = "LIC12345678",
                    IdCard = "1234567890",
                    IsActive = true,
                    Birthdate = new DateTime(1980, 5, 15),
                    Sex = 'M',
                },
                new Doctor
                {
                    Id = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"),
                    FirstName = "Jane",
                    LastName = "Smith",
                    LicenseNumber = "LIC98765432",
                    IdCard = "0987654321",
                    IsActive = false,
                    Birthdate = new DateTime(1975, 12, 1),
                    Sex = 'F',
                }
            );
        }
    }
}
