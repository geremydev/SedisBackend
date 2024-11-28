using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Medical_History.Vaccines;

namespace SedisBackend.Infrastructure.Persistence.Configurations.DomainConfigurations;

public class VaccineConfiguration : IEntityTypeConfiguration<Vaccine>
{
    public void Configure(EntityTypeBuilder<Vaccine> builder)
    {
        builder.HasData
        (
            new Vaccine
            {
                Id = Guid.Parse("308c146a-7b3e-4426-b394-971aad7e50bb"),
                Name = "Vacuna contra el tétanos",
                Doses = 1,
                Laboratory = "GlaxoSmithKline",
            },
            new Vaccine
            {
                Id = Guid.Parse("04561950-934c-47d9-a4df-55daa2143135"),
                Name = "Vacuna contra el sarampión",
                Doses = 2,
                Laboratory = "Merck",
            },
            new Vaccine
            {
                Id = Guid.Parse("9c7bed88-e92c-459d-8a50-2fd9041c2c26"),
                Name = "Vacuna contra la hepatitis B",
                Doses = 3,
                Laboratory = "Sanofi Pasteur",
            },
            new Vaccine
            {
                Id = Guid.Parse("ff079100-01b3-4902-86b0-64083d72c6fe"),
                Name = "Vacuna contra la varicela",
                Doses = 2,
                Laboratory = "Pfizer",
            },
            new Vaccine
            {
                Id = Guid.Parse("d8d4c92b-a7d9-4205-8524-829ef5ca97d7"),
                Name = "Vacuna contra el VPH",
                Doses = 2,
                Laboratory = "Merck",
            }
        );
    }
}
