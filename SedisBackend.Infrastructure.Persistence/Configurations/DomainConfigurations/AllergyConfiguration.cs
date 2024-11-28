using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Medical_History.Allergies;

namespace SedisBackend.Infrastructure.Persistence.Configurations.DomainConfigurations;

public class AllergyConfiguration : IEntityTypeConfiguration<Allergy>
{
    public void Configure(EntityTypeBuilder<Allergy> builder)
    {
        builder.HasData
        (
            new Allergy
            {
                Id = Guid.Parse("33c7785e-58f4-4ab8-9f54-51bf8978963f"),
                Title = "Rinitis alérgica",
                Description = "Inflamación de las vías nasales provocada por alérgenos a los que la persona afectada ha sido previamente sensibilizada. Su patogenia es una alergia de tipo I en la mucosa nasal. Los antígenos inhalados en la mucosa nasal sensibilizada se unen a los anticuerpos IgE en los mastocitos, que liberan mediadores químicos como la histamina y péptido leucotrieno. Como consecuencia de ello, las terminales de las neuronas sensitivas y los vasos reaccionan para inducir estornudos, rinorrea y congestión nasal (reacción de la fase inmediata). En la reacción de la fase tardía, los mastocitos producen diversos mediadores químicos, lo linfocitos Th2 y los mastocitos producen citocinas, y las células epiteliales, las células endoteliales vasculares y los fibrocitos producen quimiocinas. Estos transmisores derivados de células realmente inducen infiltración de la mucosa nasal por células inflamatorias de diversos tipos. Entre estos tipos celulares, los eosinófilos activados son los principales responsables de la inflamación de la mucosa y la hiperreactividad.\r\n",
                IcdCode = "CA08",
                PatientAllergies = new List<PatientAllergy>()
            },
            new Allergy
            {
                Id = Guid.Parse("b0fa92b6-1a21-4e9e-845e-e2d5bbfe5e1d"),
                Title = "Hipersensibilidad alimentaria",
                Description = "Efectos adversos de los alimentos o los aditivos alimentarios que se asemejan clínicamente a la alergia. La alergia alimentaria es una reacción adversa a los alimentos mediada por un mecanismo inmunitario, ya sea con implicación de IgE específica (mediada por IgE), mecanismos mediados por células (no mediada por IgE) o mecanismos mixtos mediados tanto por células como por IgE.",
                IcdCode = "4A85.2",
                PatientAllergies = new List<PatientAllergy>()
            }
        );
    }
}
