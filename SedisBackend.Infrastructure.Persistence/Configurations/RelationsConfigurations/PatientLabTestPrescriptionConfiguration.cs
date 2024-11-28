using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Infrastructure.Persistence.Configurations.RelationsConfigurations;

public class PatientLabTestPrescriptionConfiguration : IEntityTypeConfiguration<PatientLabTestPrescription>
{
    public void Configure(EntityTypeBuilder<PatientLabTestPrescription> builder)
    {
        builder.HasData
        (
            new PatientLabTestPrescription
            {
                Id = Guid.Parse("f2d5c7a1-3e4b-8f9d-1a2c-6b3e5d9f4c7a"),
                PerformedDate = DateTime.Parse("2023-06-15"),
                InvalidationDate = null,
                ResultUrl = "http://example.com/results-skin.pdf",
                Status = "Pending",

                MedicalConsultationId = Guid.Parse("5d2e7a36-91e8-4b4a-a769-854fa9d4cb29"), // Consulta para Alteraciones pigmentarias de la piel
                PatientId = Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), // Mark Abreu
                DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), // Doctor asociado
                LabTestId = Guid.Parse("1a2b3c4d-5678-9abc-def0-123456789abc"), // Test de biopsia de piel
                LabTechId = Guid.Parse("a3c9e2d7-b43f-44c1-a657-d5e5fa9a5b5c") // Técnico de laboratorio
            },
            new PatientLabTestPrescription
            {
                Id = Guid.Parse("96fdb47b-e0ad-48c6-868d-0451f4d297b2"),
                PerformedDate = DateTime.Parse("2024-02-12"),
                InvalidationDate = null,
                ResultUrl = "http://example.com/results-pulmonary-edema.pdf",
                Status = "Pending",

                MedicalConsultationId = Guid.Parse("3d4e8a71-17a5-45c7-bec6-a7934c0425bc"), // Consulta para Edema pulmonar
                PatientId = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), // Alice Smith
                DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), // Doctor asociado
                LabTestId = Guid.Parse("2b4c5d6e-789a-4fcb-ade1-23456789abcd"), // Radiografía de tórax
                LabTechId = Guid.Parse("d8f1e9b3-42a1-44d5-8f3b-6c7a9e5f6d4a") // Técnico de laboratorio
            },
            new PatientLabTestPrescription
            {
                Id = Guid.Parse("34a6c639-f539-4eb4-b19a-82a8c0cc2a49"),
                PerformedDate = DateTime.Parse("2019-08-08"),
                InvalidationDate = null,
                ResultUrl = "http://example.com/results-endoftalmitis.pdf",
                Status = "Completed",

                MedicalConsultationId = Guid.Parse("7a8b5e23-3f6b-4315-bf4e-8b7e1a5b15bc"), // Consulta para Endoftalmitis
                PatientId = Guid.Parse("ea48eb4c-01c4-44d2-a81f-fc9246d2ec20"), // Geremy Ferran
                DoctorId = Guid.Parse("f86a1609-cb84-4d6a-8d8a-8e49b6b9a5b9"), // Doctor asociado
                LabTestId = Guid.Parse("3c5d6e7f-89ab-4cde-bdef-3456789abcd0"), // Examen microbiológico ocular
                LabTechId = Guid.Parse("b4c3d9e1-2a7f-44c3-a9b1-f5e6c7a8d9f4") // Técnico de laboratorio
            }
        );
    }
}
