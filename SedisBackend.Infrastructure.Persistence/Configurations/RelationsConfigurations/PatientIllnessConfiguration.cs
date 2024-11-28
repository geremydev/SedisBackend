using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions;

namespace SedisBackend.Infrastructure.Persistence.Configurations.RelationsConfigurations;

public class PatientIllnessConfiguration : IEntityTypeConfiguration<PatientIllness>
{
    public void Configure(EntityTypeBuilder<PatientIllness> builder)
    {
        builder.HasData
        (
            new PatientIllness
            {
                PatientId = Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"),
                IllnessId = Guid.Parse("1097ba6f-7f4d-4fcc-ae34-f89cf70930a4"),
                MedicalConsultationId = Guid.Parse("5d2e7a36-91e8-4b4a-a769-854fa9d4cb29"),
                DocumentURL = "https://example.com/document/skin-pigmentation.pdf",
                DiagnosisDate = DateTime.Parse("2020-06-15"),
                Status = "Activa",
                Notes = "El paciente está bajo monitoreo y tratamiento tópico para los cambios en la pigmentación de la piel.",
                Patient = new Patient(),
                Illness = new Illness(),
                MedicalConsultation = new MedicalConsultation(),
            },
            new PatientIllness
            {
                PatientId = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
                IllnessId = Guid.Parse("99c26293-7562-4d6a-9aa1-260bedb215a6"),
                MedicalConsultationId = Guid.Parse("3d4e8a71-17a5-45c7-bec6-a7934c0425bc"),
                DocumentURL = "https://example.com/document/pulmonary-edema.pdf",
                DiagnosisDate = DateTime.Parse("2021-08-25"),
                Status = "En remisión",
                Notes = "Paciente respondió favorablemente a la terapia diurética.",
                Patient = new Patient(),
                Illness = new Illness(),
                MedicalConsultation = new MedicalConsultation(),
            },
            new PatientIllness
            {
                PatientId = Guid.Parse("ea48eb4c-01c4-44d2-a81f-fc9246d2ec20"),
                IllnessId = Guid.Parse("7791a6c3-b96b-4fd2-8777-1fabc70a3911"),
                MedicalConsultationId = Guid.Parse("7a8b5e23-3f6b-4315-bf4e-8b7e1a5b15bc"),
                DocumentURL = "https://example.com/document/endoftalmitis-diagnosis.pdf",
                DiagnosisDate = DateTime.Parse("2022-02-12"),
                Status = "Activa",
                Notes = "Tratamiento antibiótico y seguimiento con oftalmología especializado.",
                Patient = new Patient(),
                Illness = new Illness(),
                MedicalConsultation = new MedicalConsultation(),
            }
        );
    }
}
