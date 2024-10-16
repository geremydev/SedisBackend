using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Users.Doctors;

namespace SedisBackend.Infrastructure.Persistence.Configuration
{
    public class DoctorHealthCenterConfiguration : IEntityTypeConfiguration<DoctorHealthCenter>
    {
        public void Configure(EntityTypeBuilder<DoctorHealthCenter> builder)
        {
            builder.HasData
            (
                new DoctorHealthCenter
                {
                    Id = Guid.NewGuid(),
                    DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), // Doctor John Doe
                    HealthCenterId = Guid.Parse("85bc224a-c53f-41db-97b8-92f703ee4452"),
                    EntryHour = new TimeSpan(8, 0, 0), // 8:00 AM
                    ExitHour = new TimeSpan(17, 0, 0)   // 5:00 PM
                },
                new DoctorHealthCenter
                {
                    Id = Guid.NewGuid(),
                    DoctorId = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), // Doctor Jane Smith
                    HealthCenterId = Guid.Parse("57efafa6-1eec-4228-b7c1-ab87fe2097da"),
                    EntryHour = new TimeSpan(9, 0, 0), // 9:00 AM
                    ExitHour = new TimeSpan(18, 0, 0)  // 6:00 PM
                }
            );
        }
    }
}
