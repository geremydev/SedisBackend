using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Infrastructure.Persistence.Configuration;

public class PatientIllnessConfiguration : IEntityTypeConfiguration<PatientIllness>
{
    public void Configure(EntityTypeBuilder<PatientIllness> builder)
    {
        builder.HasData
        (
            new PatientIllness
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"),
                IllnessId = Guid.Parse("1097ba6f-7f4d-4fcc-ae34-f89cf70930a4"),
                DocumentURL = "https://example.com/document/diabetes-diagnosis.pdf",
                DiagnosisDate = DateTime.Parse("2019-04-23"),
                Status = "Activa",
                Notes = "Paciente monitoreado regularmente con niveles de glucosa controlados."
            },
            new PatientIllness
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
                IllnessId = Guid.Parse("99c26293-7562-4d6a-9aa1-260bedb215a6"),
                DocumentURL = "https://example.com/document/hypertension-diagnosis.pdf",
                DiagnosisDate = DateTime.Parse("2021-01-10"),
                DischargeDate = DateTime.Parse("2022-03-15"),
                Status = "En remisión",
                Notes = "Paciente responde bien al tratamiento y mantiene una presión estable."
            }
        );
    }
}
