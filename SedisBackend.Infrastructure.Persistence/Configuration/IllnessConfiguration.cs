using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions;

namespace SedisBackend.Infrastructure.Persistence.Configuration;

public class IllnessConfiguration : IEntityTypeConfiguration<Illness>
{
    public void Configure(EntityTypeBuilder<Illness> builder)
    {
        builder.HasData
        (
            new Illness
            {
                Id = Guid.Parse("1097ba6f-7f4d-4fcc-ae34-f89cf70930a4"),
                Code = "E10",
                Name = "Diabetes Mellitus Tipo 1",
                Description = "Enfermedad crónica en la que el páncreas produce poca o ninguna insulina."
            },
            new Illness
            {
                Id = Guid.Parse("99c26293-7562-4d6a-9aa1-260bedb215a6"),
                Code = "I10",
                Name = "Hipertensión esencial (primaria)",
                Description = "Condición de presión arterial elevada sin causa identificable."
            }
        );
    }
}