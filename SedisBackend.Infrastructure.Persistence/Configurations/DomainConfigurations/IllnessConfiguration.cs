using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions;

namespace SedisBackend.Infrastructure.Persistence.Configurations.DomainConfigurations;

public class IllnessConfiguration : IEntityTypeConfiguration<Illness>
{
    public void Configure(EntityTypeBuilder<Illness> builder)
    {
        builder.HasData
        (
            new Illness
            {
                Id = Guid.Parse("1097ba6f-7f4d-4fcc-ae34-f89cf70930a4"),
                IcdCode = "EH70",
                Title = "Alteraciones pigmentarias de la piel por medicamentos",
                Description = "Alteraciones del color de la piel debidas a la ingestión o la inyección de un medicamento. Pueden obedecer a diferentes mecanismos, como el color del propio medicamento, una alteración de la melanización cutánea o el depósito de pigmentos por productos de degradación del fármaco."
            },
            new Illness
            {
                Id = Guid.Parse("99c26293-7562-4d6a-9aa1-260bedb215a6"),
                IcdCode = "CB01",
                Title = "Edema pulmonar",
                Description = "Afección causada por un exceso de líquido en los pulmones. Este líquido se acumula en los numerosos sacos alveolares de los pulmones, lo cual dificulta la respiración.\r\n"
            },
            new Illness
            {
                Id = Guid.Parse("7791a6c3-b96b-4fd2-8777-1fabc70a3911"),
                IcdCode = "9C21",
                Title = "Endoftalmitis",
                Description = ""
            }
        );
    }
}