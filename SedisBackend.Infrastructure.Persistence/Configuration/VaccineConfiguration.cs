using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Medical_History.Vaccines;

namespace SedisBackend.Infrastructure.Persistence.Configuration;

public class VaccineConfiguration : IEntityTypeConfiguration<Vaccine>
{
    public void Configure(EntityTypeBuilder<Vaccine> builder)
    {
        builder.HasData
        (
            new Vaccine
            {
                Id = Guid.Parse("c28e855d-2602-423f-a4d5-26954df029da"),
                Name = "Vacuna COVID-19",
                Doses = 2,
                Laboratory = "Pfizer-BioNTech"
            },
            new Vaccine
            {
                Id = Guid.Parse("384e34fb-7d23-4123-a78e-13d7b0a91110"),
                Name = "Vacuna contra la gripe",
                Doses = 1,
                Laboratory = "Sanofi Pasteur"
            }
        );
    }
}
