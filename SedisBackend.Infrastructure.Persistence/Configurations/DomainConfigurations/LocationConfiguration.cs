using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Models;

namespace SedisBackend.Infrastructure.Persistence.Configurations.DomainConfigurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasData
        (
            new Location
            {
                Id = Guid.Parse("a1c1b2c3-d4e5-678f-1234-56789abcdef0"),
                EntityId = Guid.Parse("85bc224a-c53f-41db-97b8-92f703ee4452"), // Hospital General Dr. Darío Contreras
                EntityType = "HealthCenter",
                RegionId = Guid.Parse("12345678-1234-1234-1234-1234567890ab"),
                ProvinceId = Guid.Parse("23456789-2345-2345-2345-234567890abc"),
                MunicipalityId = Guid.Parse("34567890-3456-3456-3456-34567890abcd"),
                PostalCode = "10101",
                Longitude = -69.8791m,
                Latitude = 18.4861m
            },
            new Location
            {
                Id = Guid.Parse("b2c3d4e5-f678-1234-5678-abcdef123456"),
                EntityId = Guid.Parse("57efafa6-1eec-4228-b7c1-ab87fe2097da"), // Centro de Diagnóstico Médico (CDM)
                EntityType = "HealthCenter",
                RegionId = Guid.Parse("87654321-4321-4321-4321-abcdef123456"),
                ProvinceId = Guid.Parse("76543210-5432-5432-5432-abcdef234567"),
                MunicipalityId = Guid.Parse("65432109-6543-6543-6543-abcdef345678"),
                PostalCode = "10202",
                Longitude = -70.1626m,
                Latitude = 19.4517m
            },
            new Location
            {
                Id = Guid.Parse("c3d4e5f6-1234-5678-9abc-def123456789"),
                EntityId = Guid.Parse("deb707b2-50f1-4245-9f8d-12a3b6e74933"), // Clínica Unión Médica del Norte
                EntityType = "HealthCenter",
                RegionId = Guid.Parse("45678901-2345-3456-4567-abcdef678901"),
                ProvinceId = Guid.Parse("56789012-3456-4567-5678-abcdef789012"),
                MunicipalityId = Guid.Parse("67890123-4567-5678-6789-abcdef890123"),
                PostalCode = "10303",
                Longitude = -71.2992m,
                Latitude = 19.4667m
            },
            new Location
            {
                Id = Guid.Parse("d4e5f678-2345-3456-4567-890abcdef123"),
                EntityId = Guid.Parse("c8b0812e-7205-40ad-a249-fb9e6ae64c37"), // HGENSA
                EntityType = "HealthCenter",
                RegionId = Guid.Parse("09876543-2109-8765-4321-fedcba987654"),
                ProvinceId = Guid.Parse("98765432-1098-7654-3210-fedcba876543"),
                MunicipalityId = Guid.Parse("87654321-0987-6543-2109-fedcba765432"),
                PostalCode = "10404",
                Longitude = -69.9112m,
                Latitude = 18.5398m
            },
            new Location
            {
                Id = Guid.Parse("e5f67890-3456-4567-5678-90abcdef1234"),
                EntityId = Guid.Parse("8b971b1f-3f6e-46a8-9b27-805af468bbb4"), // Centro Médico Cibao
                EntityType = "HealthCenter",
                RegionId = Guid.Parse("76543210-9876-5432-1098-fedcba654321"),
                ProvinceId = Guid.Parse("65432109-8765-4321-0987-fedcba543210"),
                MunicipalityId = Guid.Parse("54321098-7654-3210-9876-fedcba432109"),
                PostalCode = "10505",
                Longitude = -70.6872m,
                Latitude = 19.1873m
            }
        );
    }
}
