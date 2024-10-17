﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Users.Assistants;

namespace SedisBackend.Infrastructure.Persistence.Configuration
{
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
                    IdCard = "0987634321",
                    IsActive = false,
                    Birthdate = new DateTime(1975, 12, 1),
                    Sex = 'F',
                }
            );
        }
    }

}
