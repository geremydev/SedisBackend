using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Users.Persons;

namespace SedisBackend.Infrastructure.Persistence.Configuration.UsersConfiguration;
internal class AssistantConfiguration : IEntityTypeConfiguration<Assistant>
{
    public void Configure(EntityTypeBuilder<Assistant> builder)
    {
        builder.HasData
        (
            new Assistant
            {
                Id = Guid.Parse("37439d05-9b3b-4896-88e0-4ee7b7221a8b"),
                HealthCenterId = Guid.Parse("deb707b2-50f1-4245-9f8d-12a3b6e74933"),
            }
        );
    }
}
