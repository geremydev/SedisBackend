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
                StartTime = new TimeSpan(8, 0, 0),
                EndTime = new TimeSpan(16, 0, 0),
                Status = true
            },
            new HealthCenterServices
            {
                HealthCenterId = Guid.Parse("57efafa6-1eec-4228-b7c1-ab87fe2097da"),
                ServiceId = Guid.NewGuid(), // Asocia el ID de un servicio real
                CreationDate = DateTime.UtcNow,
                StartTime = new TimeSpan(9, 0, 0),
                EndTime = new TimeSpan(17, 0, 0),
                Status = true
            }
            // Agrega más relaciones de servicios a centros de salud según sea necesario
        );
    }
}
