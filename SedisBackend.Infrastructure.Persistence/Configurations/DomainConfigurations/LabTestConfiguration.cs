using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Models.Products;

namespace SedisBackend.Infrastructure.Persistence.Configurations.DomainConfigurations;

public class LabTestConfiguration : IEntityTypeConfiguration<LabTest>
{
    public void Configure(EntityTypeBuilder<LabTest> builder)
    {
        builder.HasData
        (
            new LabTest
            {
                Id = Guid.Parse("9d2a5e4c-8b3f-4a7d-9c5b-3f2e1b6a7d9c"),
                TestName = "Hemograma Completo",
                TestCode = "H001",
                Status = true
            },
            new LabTest
            {
                Id = Guid.Parse("2b5d9a1c-4e7f-3a8c-6b9d-5f2a3e4b1f7a"),
                TestName = "Perfil Lipídico",
                TestCode = "P002",
                Status = true
            },
            new LabTest
            {
                Id = Guid.Parse("ab3f3482-973d-4912-8848-f82bbb107792"), // Test de biopsia de piel
                TestName = "Biopsia de piel",
                TestCode = "B003",
                Status = true
            },
            new LabTest
            {
                Id = Guid.Parse("3c5d6e7f-89ab-4cde-bdef-3456789abcd0"), // Examen microbiológico ocular
                TestName = "Examen microbiológico ocular",
                TestCode = "M004",
                Status = true
            },
            new LabTest
            {
                Id = Guid.Parse("0c8b53f4-6962-4f89-807e-737900741e13"), // Radiografía de tórax
                TestName = "Radiografía de tórax",
                TestCode = "R005",
                Status = true
            }
        );
    }
}
