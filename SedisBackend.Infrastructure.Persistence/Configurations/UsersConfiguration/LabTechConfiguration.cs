using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Users.Persons;

namespace SedisBackend.Infrastructure.Persistence.Configurations.UsersConfiguration;
internal class LabTechConfiguration : IEntityTypeConfiguration<LabTech>
{
    public void Configure(EntityTypeBuilder<LabTech> builder)
    {
        builder.HasData
        (
            new LabTech
            {
                Id = Guid.Parse("a3c9e2d7-b43f-44c1-a657-d5e5fa9a5b5c"),
                Status = true,
                HealthCenterId = Guid.Parse("c8b0812e-7205-40ad-a249-fb9e6ae64c37"),
            },
            new LabTech
            {
                Id = Guid.Parse("d8f1e9b3-42a1-44d5-8f3b-6c7a9e5f6d4a"),
                Status = true,
                HealthCenterId = Guid.Parse("8b971b1f-3f6e-46a8-9b27-805af468bbb4"),
            },
            new LabTech
            {
                Id = Guid.Parse("b4c3d9e1-2a7f-44c3-a9b1-f5e6c7a8d9f4"),
                Status = true,
                HealthCenterId = Guid.Parse("deb707b2-50f1-4245-9f8d-12a3b6e74933"),
            }
        );
    }
}
