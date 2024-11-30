using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Entities.Users.Persons;

namespace SedisBackend.Infrastructure.Persistence.Configurations.DomainConfigurations;

public class HealthCenterConfiguration : IEntityTypeConfiguration<HealthCenter>
{
    public void Configure(EntityTypeBuilder<HealthCenter> builder)
    {
        builder.HasData
        (
             new HealthCenter
             {
                 Id = Guid.Parse("85bc224a-c53f-41db-97b8-92f703ee4452"),
                 Name = "Hospital General Dr. Darío Contreras",
                 LocationId = Guid.Parse("a1c1b2c3-d4e5-678f-1234-56789abcdef0"),
                 HealthCenterCategory = "General",
                 Status = true
             },
            new HealthCenter
            {
                Id = Guid.Parse("57efafa6-1eec-4228-b7c1-ab87fe2097da"),
                Name = "Centro de Diagnóstico Médico (CDM)",
                LocationId = Guid.Parse("b2c3d4e5-f678-1234-5678-abcdef123456"),
                HealthCenterCategory = "Specialized",
                Status = true
            },
            new HealthCenter
            {
                Id = Guid.Parse("deb707b2-50f1-4245-9f8d-12a3b6e74933"),
                Name = "Clínica Unión Médica del Norte",
                LocationId = Guid.Parse("c3d4e5f6-1234-5678-9abc-def123456789"),
                HealthCenterCategory = "General",
                Status = true
            },
            new HealthCenter
            {
                Id = Guid.Parse("c8b0812e-7205-40ad-a249-fb9e6ae64c37"),
                Name = "Hospital General y de Especialidades Nuestra Señora de la Altagracia (HGENSA)",
                LocationId = Guid.Parse("d4e5f678-2345-3456-4567-890abcdef123"),
                HealthCenterCategory = "General",
                Status = true
            },
            new HealthCenter
            {
                Id = Guid.Parse("8b971b1f-3f6e-46a8-9b27-805af468bbb4"),
                Name = "Centro Médico Cibao",
                LocationId = Guid.Parse("e5f67890-3456-4567-5678-90abcdef1234"),
                HealthCenterCategory = "Specialized",
                Status = false
            }
        );
    }
}
