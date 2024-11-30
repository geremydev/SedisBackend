using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Users.Persons;

namespace SedisBackend.Infrastructure.Persistence.Configuration.UsersConfiguration;
internal class AdminConfiguration : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.HasData
        (
            new Admin
            {
                Id = Guid.Parse("f86a1609-cb84-4d6a-8d8a-8e49b6b9a5b9"),
                HealthCenterId = Guid.Parse("85bc224a-c53f-41db-97b8-92f703ee4452"),
                Status = true
            },
            new Admin
            {
                Id = Guid.Parse("ea48eb4c-01c4-44d2-a81f-fc9246d2ec20"),
                HealthCenterId = Guid.Parse("deb707b2-50f1-4245-9f8d-12a3b6e74933"),
                Status = true
            }
        );
    }
}
