using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Users.Persons;

namespace SedisBackend.Infrastructure.Persistence.Configuration;
internal class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasData
        (
            new Patient
            {
                Id = Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"),
                BloodType = "A-",
                BloodTypeLabResultURl = "http://example.com/lab-results/alice-smith",
                Height = 165.2m,
                Weight = 60.8m,
                EmergencyContactName = "Bob Smith",
                EmergencyContactPhone = "987-654-3210",
            },
            new Patient
            {
                Id = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
                BloodType = "O+",
                BloodTypeLabResultURl = "http://example.com/lab-results/john-doe",
                Height = 180.5m,
                Weight = 75.3m,
                EmergencyContactName = "Jane Doe",
                EmergencyContactPhone = "123-456-7890",
            }
        );
    }
}
