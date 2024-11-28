using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Infrastructure.Persistence.Configurations.RelationsConfigurations;

public class PatientDiscapacityConfiguration : IEntityTypeConfiguration<PatientDiscapacity>
{
    public void Configure(EntityTypeBuilder<PatientDiscapacity> builder)
    {
        builder.HasData
        (
            new PatientDiscapacity
            {
                PatientId = Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"),
                DiscapacityId = Guid.Parse("1b54e13f-7a32-4cc1-ad6d-35298426a2fb"),
                DiagnosisDate = DateTime.Parse("2018-05-15"),
                Severity = "Severa",
                Description = "El paciente presenta dificultades visuales complejas.",
                Status = true,
                MedicalConsultationId = Guid.Parse("84f2c6b1-3a45-4c12-b5af-81f8576bcd49")
            },
            new PatientDiscapacity
            {
                PatientId = Guid.Parse("d9a832b8-123a-4c98-baba-6e2a32e94b9e"),
                DiscapacityId = Guid.Parse("5c52a9d3-6ee2-496e-a922-139de857d9d4"),
                DiagnosisDate = DateTime.Parse("2020-11-20"),
                Severity = "Moderada",
                Description = "El paciente presenta pérdida auditiva moderada desde el nacimiento.",
                Status = true,
                MedicalConsultationId = Guid.Parse("91a82d3e-5276-4ab9-bc2f-05b8b174ccd7") // Ejemplo consulta médica
            },
            new PatientDiscapacity
            {
                PatientId = Guid.Parse("e2a4d5b6-3c9a-47bc-8db1-cd327a2f92d6"), // Paciente Luis Santos
                DiscapacityId = Guid.Parse("1b54e13f-7a32-4cc1-ad6d-35298426a2fb"), // Disfunciones complejas relacionadas con la visión
                DiagnosisDate = DateTime.Parse("2019-07-10"),
                Severity = "Leve",
                Description = "El paciente requiere soporte para tareas visuales prolongadas.",
                Status = true,
                MedicalConsultationId = Guid.Parse("eb3c9f01-abc6-4e17-a2a8-8c194f2bc938") // Ejemplo consulta médica
            }
        );
    }
}
