using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Enums;

namespace SedisBackend.Infrastructure.Persistence.Configuration;

public class AssistantConfiguration : IEntityTypeConfiguration<Assistant>
{
    public void Configure(EntityTypeBuilder<Assistant> builder)
    {
        builder.HasData
        (
            new Assistant
            {
                Id = Guid.NewGuid(),
                HealthCenterId = Guid.Parse("85bc224a-c53f-41db-97b8-92f703ee4452"), // ID de HealthCenter
                FirstName = "Ana",
                LastName = "Martínez",
                CardId = "0987634321",
                IsActive = false,
                Birthdate = new DateTime(1995, 12, 1),
                Sex = SexEnum.F,
            }
        );
    }
}
