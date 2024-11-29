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
                MedicalConsultationId = Guid.Parse("7a8b5e23-3f6b-4315-bf4e-8b7e1a5b15bc")
            },
            new PatientDiscapacity
            {
                PatientId = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
                DiscapacityId = Guid.Parse("5c52a9d3-6ee2-496e-a922-139de857d9d4"),
                DiagnosisDate = DateTime.Parse("2020-11-20"),
                Severity = "Moderada",
                Description = "El paciente presenta pérdida auditiva moderada desde el nacimiento.",
                Status = true,
                MedicalConsultationId = Guid.Parse("2c4f7b60-71a9-4ea8-82f1-7f3c0dbed832") // Ejemplo consulta médica
            },
            new PatientDiscapacity
            {
                PatientId = Guid.Parse("e2a4d5b6-3c9a-47bc-8db1-cd327a2f92d6"), // Paciente Luis Santos
                DiscapacityId = Guid.Parse("1b54e13f-7a32-4cc1-ad6d-35298426a2fb"), // Disfunciones complejas relacionadas con la visión
                DiagnosisDate = DateTime.Parse("2019-07-10"),
                Severity = "Leve",
                Description = "El paciente requiere soporte para tareas visuales prolongadas.",
                Status = true,
                MedicalConsultationId = Guid.Parse("5d2e7a36-91e8-4b4a-a769-854fa9d4cb29") // Ejemplo consulta médica
            }
        );
    }
}
