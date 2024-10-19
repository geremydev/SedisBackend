using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Models;

namespace SedisBackend.Infrastructure.Persistence.Configuration;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasData
        (
            new Location
            {
                Id = Guid.Parse("945e98f3-80c7-4444-8d93-74b72efc78b1"),
                EntityId = Guid.Parse("85bc224a-c53f-41db-97b8-92f703ee4452"), // Associated with a Health Center
                EntityType = "HealthCenter",
                RegionId = Guid.Parse("12345678-1234-1234-1234-1234567890ab"),
                ProvinceId = Guid.Parse("23456789-2345-2345-2345-234567890abc"),
                MunicipalityId = Guid.Parse("34567890-3456-3456-3456-34567890abcd"),
                PostalCode = "10101",
                Longitude = -69.8937m,
                Latitude = 18.5067m
            },
            new Location
            {
                Id = Guid.Parse("57efafa6-1eec-4228-b7c1-ab87fe2097da"),
                EntityId = Guid.Parse("a6e819b6-3996-49d6-afc7-9b47206dcadc"), // Associated with a Doctor
                EntityType = "HealthCenter",
                RegionId = Guid.Parse("87654321-4321-4321-4321-abcdef123456"),
                ProvinceId = Guid.Parse("76543210-5432-5432-5432-abcdef234567"),
                MunicipalityId = Guid.Parse("65432109-6543-6543-6543-abcdef345678"),
                PostalCode = "10202",
                Longitude = -69.9010m,
                Latitude = 18.4796m
            }
        );
    }
}
