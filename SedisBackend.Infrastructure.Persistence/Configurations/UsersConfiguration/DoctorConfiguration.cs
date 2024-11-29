using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Users.Persons;

namespace SedisBackend.Infrastructure.Persistence.Configuration.UsersConfiguration;
internal class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasData
        (
            new Doctor
            {
                Id = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                LicenseNumber = "LIC12345678",
                CurrentlyWorkingHealthCenterId = Guid.Parse("85bc224a-c53f-41db-97b8-92f703ee4452")
            },
            new Doctor
            {
                Id = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"),
                LicenseNumber = "LIC98765432",
                CurrentlyWorkingHealthCenterId = Guid.Parse("57efafa6-1eec-4228-b7c1-ab87fe2097da"),
            }
        );
    }
}
