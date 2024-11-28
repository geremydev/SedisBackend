using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Enums;
using SedisBackend.Core.Domain.Medical_History.Family_History;

namespace SedisBackend.Infrastructure.Persistence.Configurations.DomainConfigurations;
public class FamilyHistoryConfiguration : IEntityTypeConfiguration<FamilyHistory>
{
    public void Configure(EntityTypeBuilder<FamilyHistory> builder)
    {
        builder.HasData
        (
            new FamilyHistory
            {
                Id = Guid.Parse("1b54e13f-7a32-4cc1-ad6d-35298426a2fb"),
                PatientId = Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"),
                RelativeId = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
                Condition = "",
                Relationship = FamilyTie.Mother.ToString(),
                Status = true,
            },
            new FamilyHistory
            {
                Id = Guid.Parse("5c52a9d3-6ee2-496e-a922-139de857d9d4"),
                PatientId = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
                RelativeId = Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"),
                Condition = "",
                Relationship = FamilyTie.Son.ToString(),
                Status = false,
            },
            new FamilyHistory
            {
                Id = Guid.Parse("d7446d5f-93b0-4c94-8e10-ba5567f50b7b"),
                PatientId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                RelativeId = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
                Condition = "",
                Relationship = FamilyTie.Aunt.ToString(),
                Status = false,
            }
        );
    }
}
