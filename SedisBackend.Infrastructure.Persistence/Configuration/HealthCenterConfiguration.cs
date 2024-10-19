using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Models;

namespace SedisBackend.Infrastructure.Persistence.Configuration;

public class HealthCenterConfiguration : IEntityTypeConfiguration<HealthCenter>
{
    public void Configure(EntityTypeBuilder<HealthCenter> builder)
    {
        builder.HasData
        (
             new HealthCenter
             {
                 Id = Guid.Parse("85bc224a-c53f-41db-97b8-92f703ee4452"),
                 Name = "Central Health Center",
                 LocationId = Guid.Parse("945e98f3-80c7-4444-8d93-74b72efc78b1"),
                 HealthCenterCategory = "General" // HealthCenterCategory.General
             },
            new HealthCenter
            {
                Id = Guid.Parse("57efafa6-1eec-4228-b7c1-ab87fe2097da"),
                Name = "North Health Center",
                LocationId = Guid.Parse("a6e819b6-3996-49d6-afc7-9b47206dcadc"),
                HealthCenterCategory = "Especializado" // HealthCenterCategory.Specialized
            }
        );
    }
}
