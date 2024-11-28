using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Discapacity_Condition;

namespace SedisBackend.Infrastructure.Persistence.Configurations.DomainConfigurations;

public class DiscapacityConfiguration : IEntityTypeConfiguration<Discapacity>
{
    public void Configure(EntityTypeBuilder<Discapacity> builder)
    {
        builder.HasData
        (
            new Discapacity
            {
                Id = Guid.Parse("1b54e13f-7a32-4cc1-ad6d-35298426a2fb"),
                IcdCode = "9D93",
                Title = "Disfunciones complejas relacionadas con la visión",
                Description = "Grupo de disfunciones visuales que implican interacciones con otros sistemas sensitivos y motores. Reflejan los efectos combinados en todas las etapas de procesamiento.\r\n",
                PatientDiscapacities = new List<PatientDiscapacity>(),
            },
            new Discapacity
            {
                Id = Guid.Parse("5c52a9d3-6ee2-496e-a922-139de857d9d4"),
                IcdCode = "AB50",
                Title = "Deficiencia auditiva congénita",
                Description = "Hay genes dominantes y recesivos que pueden causar una discapacidad de leve a profunda. Si una familia posee un gen de la sordera dominante, el gen persistirá a lo largo de las generaciones porque basta con que se herede de un solo progenitor para que se manifieste en la descendencia. En cambio, si una familia tiene una discapacidad auditiva genética causada por un gen recesivo, este no siempre se manifestará, puesto que ello ocurre solo cuando ambos padres lo transmiten a sus descendientes. La discapacidad auditiva se produce antes de la adquisición del lenguaje por tratarse de una afección congénita.\r\n",
                PatientDiscapacities = new List<PatientDiscapacity>(),
            }
        );
    }
}
