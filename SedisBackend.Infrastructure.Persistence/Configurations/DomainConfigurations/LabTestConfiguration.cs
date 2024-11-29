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
            }
        );
    }
}
