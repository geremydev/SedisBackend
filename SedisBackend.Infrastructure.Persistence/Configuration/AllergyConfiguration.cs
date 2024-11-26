using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Medical_History.Allergies;

namespace SedisBackend.Infrastructure.Persistence.Configuration;

public class AllergyConfiguration : IEntityTypeConfiguration<Allergy>
{
    public void Configure(EntityTypeBuilder<Allergy> builder)
    {
        builder.HasData
        (
            new Allergy
            {
                Id = Guid.Parse("33c7785e-58f4-4ab8-9f54-51bf8978963f"),
                Allergen = "Peanuts",
                IcdCode = "123123"
            },
            new Allergy
            {
                Id = Guid.Parse("b0fa92b6-1a21-4e9e-845e-e2d5bbfe5e1d"),
                Allergen = "Penicillin",
                IcdCode = "123123"
            }
        );
    }
}
