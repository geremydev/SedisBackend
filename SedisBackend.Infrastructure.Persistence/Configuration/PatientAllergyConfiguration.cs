using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Infrastructure.Persistence.Configuration;

public class PatientAllergyConfiguration : IEntityTypeConfiguration<PatientAllergy>
{
    public void Configure(EntityTypeBuilder<PatientAllergy> builder)
    {
        builder.HasData
        (
            new PatientAllergy
            {
                PatientId = Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"),
                AllergyId = Guid.Parse("33c7785e-58f4-4ab8-9f54-51bf8978963f"), // Peanuts
                Allergen = "Peanuts",
                AllergicReaction = "Anaphylaxis",
                DiagnosisDate = DateTime.Parse("2020-05-18"),
                Description = "Cuadro anafiláctivo grave",
                Status = true
            },
            new PatientAllergy
            {
                PatientId = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
                AllergyId = Guid.Parse("b0fa92b6-1a21-4e9e-845e-e2d5bbfe5e1d"), // Penicillin
                Allergen = "Penicilin",
                AllergicReaction = "Rash",
                DiagnosisDate = DateTime.Parse("2019-11-07"),
                Description = "Rash grave",
                Status = true
            }
        );
    }
}
