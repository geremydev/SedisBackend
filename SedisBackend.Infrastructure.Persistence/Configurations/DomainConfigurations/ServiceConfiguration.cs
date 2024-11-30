using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Models;

namespace SedisBackend.Infrastructure.Persistence.Configurations.DomainConfigurations;
internal class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasData
        (
            new Service
            {
                Id = Guid.NewGuid(),
                Name = "Consulta General",
                Description = "Servicio de consulta médica general",
                ImageURL = "https://example.com/images/general-consultation.jpg"
            },
            new Service
            {
                Id = Guid.NewGuid(),
                Name = "Emergencias",
                Description = "Servicio de atención a emergencias médicas",
                ImageURL = "https://example.com/images/emergencies.jpg"
            },
            new Service
            {
                Id = Guid.NewGuid(),
                Name = "Radiología",
                Description = "Servicio de imágenes médicas y radiografías",
                ImageURL = "https://example.com/images/radiology.jpg"
            },
            new Service
            {
                Id = Guid.NewGuid(),
                Name = "Laboratorio Clínico",
                Description = "Servicio de análisis de laboratorio",
                ImageURL = "https://example.com/images/laboratory.jpg"
            }
        );
    }
}
