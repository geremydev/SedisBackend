using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Infrastructure.Persistence.Configurations.RelationsConfigurations;
public class HealthCenterServicesConfiguration : IEntityTypeConfiguration<HealthCenterServices>
{
    public void Configure(EntityTypeBuilder<HealthCenterServices> builder)
    {
        builder.HasKey(hcs => new { hcs.HealthCenterId, hcs.ServiceId });

        builder.HasData
        (
            new HealthCenterServices
            {
                HealthCenterId = Guid.Parse("85bc224a-c53f-41db-97b8-92f703ee4452"),
                ServiceId = Guid.NewGuid(), // Asocia el ID de un servicio real
                CreationDate = DateTime.UtcNow,
                AdditionalInformation = "Lo ofrecemos gratis si eres lindo",
                Address = "Calle f",
                Cost = "100 DOP",
                Department = "Departamento de Salud",
                Email = "salud@hospital.com",
                Description = "Servicio brindado por nosotros",
                OperatingHours = "de 7am a 8pm",
                PhoneNumber = "8099298782",
                Requirements = "cédula",
                Status = true
            },
            new HealthCenterServices
            {
                HealthCenterId = Guid.Parse("57efafa6-1eec-4228-b7c1-ab87fe2097da"),
                ServiceId = Guid.NewGuid(), // Asocia el ID de un servicio real
                CreationDate = DateTime.UtcNow,
                AdditionalInformation = "Lo ofrecemos gratis si eres lindo",
                Address = "Calle f",
                Cost = "100 DOP",
                Department = "Departamento de Salud",
                Email = "salud@hospital.com",
                Description = "Servicio brindado por nosotros",
                OperatingHours = "de 7am a 8pm",
                PhoneNumber = "8099298782",
                Requirements = "cédula",
                Status = true
            }
            // Agrega más relaciones de servicios a centros de salud según sea necesario
        );
    }
}
