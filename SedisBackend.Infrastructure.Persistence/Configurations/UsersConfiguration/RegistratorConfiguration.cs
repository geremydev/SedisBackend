using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Users.Persons;

namespace SedisBackend.Infrastructure.Persistence.Configurations.UsersConfiguration;
internal class RegistratorConfiguration : IEntityTypeConfiguration<Registrator>
{
    public void Configure(EntityTypeBuilder<Registrator> builder)
    {
        builder.HasData
        (
            new Registrator
            {
                Id = Guid.Parse("37439d05-9b3b-4896-88e0-4ee7b7221a8b"),
                HealthCenterId = Guid.Parse("85bc224a-c53f-41db-97b8-92f703ee4452"),
            },
            new Registrator
            {
                Id = Guid.Parse("37439d05-9b3b-4896-88e0-4ee7b7221a8b"),
                HealthCenterId = Guid.Parse("85bc224a-c53f-41db-97b8-92f703ee4452"), // Hospital General Dr. Darío Contreras
            },
            new Registrator
            {
                Id = Guid.Parse("83d48d7c-6a56-4233-9934-9d30bde63bb5"),
                HealthCenterId = Guid.Parse("57efafa6-1eec-4228-b7c1-ab87fe2097da"), // Centro de Diagnóstico Médico (CDM)
            },
            new Registrator
            {
                Id = Guid.Parse("9c87b12f-d892-4f2b-8e2c-5347c8c1b056"),
                HealthCenterId = Guid.Parse("deb707b2-50f1-4245-9f8d-12a3b6e74933"), // Clínica Unión Médica del Norte
            },
            new Registrator
            {
                Id = Guid.Parse("b7e1e44d-72c9-4c91-a933-9e4f0e6b5f11"),
                HealthCenterId = Guid.Parse("c8b0812e-7205-40ad-a249-fb9e6ae64c37"), // Hospital General y de Especialidades Nuestra Señora de la Altagracia
            },
            new Registrator
            {
                Id = Guid.Parse("e2a4d5b6-3c9a-47bc-8db1-cd327a2f92d6"),
                HealthCenterId = Guid.Parse("8b971b1f-3f6e-46a8-9b27-805af468bbb4"), // Centro Médico Cibao
            }
        );
    }
}
