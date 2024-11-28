using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Infrastructure.Persistence.Configurations.RelationsConfigurations;

public class PatientRiskFactorConfiguration : IEntityTypeConfiguration<PatientRiskFactor>
{
    public void Configure(EntityTypeBuilder<PatientRiskFactor> builder)
    {
        builder.HasData
        (
            new PatientRiskFactor
            {
                PatientId = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
                RiskFactorId = Guid.Parse("a34f2c12-d4b6-42e9-8f7a-9012c3e4f567"),
                MedicalConsultationId = Guid.Parse("3d4e8a71-17a5-45c7-bec6-a7934c0425bc"),
                Status = "Activo",
                DiagnosisDate = DateTime.Parse("2023-01-10"),
            },
            new PatientRiskFactor
            {
                PatientId = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
                RiskFactorId = Guid.Parse("b78f3e45-c5d6-47e1-a9f8-3456d7e8f901"),
                MedicalConsultationId = Guid.Parse("3d4e8a71-17a5-45c7-bec6-a7934c0425bc"),
                Status = "En tratamiento",
                DiagnosisDate = DateTime.Parse("2023-02-15"),
            },

            new PatientRiskFactor
            {
                PatientId = Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"),
                RiskFactorId = Guid.Parse("c98f4e56-d7f8-489a-b9e1-4567e8f9a012"),
                MedicalConsultationId = Guid.Parse("5d2e7a36-91e8-4b4a-a769-854fa9d4cb29"),
                Status = "Activo",
                DiagnosisDate = DateTime.Parse("2021-11-05"),
            },

            new PatientRiskFactor
            {
                PatientId = Guid.Parse("ea48eb4c-01c4-44d2-a81f-fc9246d2ec20"),
                RiskFactorId = Guid.Parse("f45f7e89-a1c2-4b5d-bcde-67890a1b2345"),
                MedicalConsultationId = Guid.Parse("7a8b5e23-3f6b-4315-bf4e-8b7e1a5b15bc"),
                Status = "Activo",
                DiagnosisDate = DateTime.Parse("2020-05-20"),
            }
        );
    }
}
