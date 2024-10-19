using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Enums;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Discapacity_Condition;

namespace SedisBackend.Infrastructure.Persistence.Configuration;

public class DiscapacityConfiguration : IEntityTypeConfiguration<Discapacity>
{
    public void Configure(EntityTypeBuilder<Discapacity> builder)
    {
        builder.HasData
        (
            new Discapacity
            {
                Id = Guid.Parse("1b54e13f-7a32-4cc1-ad6d-35298426a2fb"),
                Type = DiscapacityType.Physical,
                Description = "Paraplejia que afecta las extremidades inferiores."
            },
            new Discapacity
            {
                Id = Guid.Parse("5c52a9d3-6ee2-496e-a922-139de857d9d4"),
                Type = DiscapacityType.Sensory,
                Description = "Pérdida total de la audición en ambos oídos."
            }
        );
    }
}
