using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Users;
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
                ApplicationUser = new User
                {
                    Id = Guid.Parse("a3c9e2d7-b43f-44c1-a657-d5e5fa9a5b5c")
                }
            },
            new LabTech
            {
                Id = Guid.Parse("d8f1e9b3-42a1-44d5-8f3b-6c7a9e5f6d4a"),
                Status = true,
                ApplicationUser = new User
                {
                    Id = Guid.Parse("d8f1e9b3-42a1-44d5-8f3b-6c7a9e5f6d4a")
                }
            },
            new LabTech
            {
                Id = Guid.Parse("b4c3d9e1-2a7f-44c3-a9b1-f5e6c7a8d9f4"),
                Status = true,
                ApplicationUser = new User
                {
                    Id = Guid.Parse("b4c3d9e1-2a7f-44c3-a9b1-f5e6c7a8d9f4")
                }
            }
        );
    }
}
