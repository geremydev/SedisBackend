using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Infrastructure.Persistence.Configurations.RelationsConfigurations;
public class PatientMedicationPrescriptionConfiguration : IEntityTypeConfiguration<PatientMedicationPrescription>
{
    public void Configure(EntityTypeBuilder<PatientMedicationPrescription> builder)
    {
        builder.HasData
        (
            new PatientMedicationPrescription
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"),
                MedicationId = Guid.Parse("a2d1c5b7-8f4e-4a6b-9c3d-5e7a1b2c9f5d"),
                DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                StartDate = new DateTime(2024, 01, 01),
                EndDate = new DateTime(2024, 06, 01),
                Notes = "Iniciar tratamiento para controlar la glucosa.",
                Status = true,
                MedicalConsultationId = Guid.Parse("5d2e7a36-91e8-4b4a-a769-854fa9d4cb29")
            },
            new PatientMedicationPrescription
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
                MedicationId = Guid.Parse("c3a1a1e3-e2b5-42ac-8b34-358ea7745d6e"),
                DoctorId = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"),
                StartDate = new DateTime(2024, 03, 01),
                EndDate = new DateTime(2024, 03, 15),
                Notes = "Tratamiento para el dolor abdominal severo y fiebre.",
                Status = true,
                MedicalConsultationId = Guid.Parse("2c4f7b60-71a9-4ea8-82f1-7f3c0dbed832")

            },
            new PatientMedicationPrescription
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.Parse("ea48eb4c-01c4-44d2-a81f-fc9246d2ec20"),
                MedicationId = Guid.Parse("f1c839fa-d3f8-433d-b6e3-e8d5296d22d9"),
                DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                StartDate = new DateTime(2024, 02, 15),
                EndDate = new DateTime(2024, 03, 01),
                Notes = "Medicamento para el dolor articular y la inflamación.",
                Status = true,
                MedicalConsultationId = Guid.Parse("8f7319e7-89b4-4d5c-90cb-cf2e5a0c9fbd")
            },
            new PatientMedicationPrescription
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.Parse("f86a1609-cb84-4d6a-8d8a-8e49b6b9a5b9"),
                MedicationId = Guid.Parse("4b2c6894-cc7d-4565-bb18-aba013826de7"),
                DoctorId = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"),
                StartDate = new DateTime(2024, 03, 05),
                EndDate = new DateTime(2024, 06, 05),
                Notes = "Tratamiento para depresión y ansiedad.",
                Status = true,
                MedicalConsultationId = Guid.Parse("3d4e8a71-17a5-45c7-bec6-a7934c0425bc")
            },
            new PatientMedicationPrescription
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.Parse("37439d05-9b3b-4896-88e0-4ee7b7221a8b"),
                MedicationId = Guid.Parse("e4c9b8d4-9a5d-44d3-9be7-85e2e57b73c1"),
                DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                StartDate = new DateTime(2024, 01, 15),
                EndDate = new DateTime(2024, 07, 15),
                Notes = "Tratamiento para hipertensión.",
                Status = true,
                MedicalConsultationId = Guid.Parse("8f7319e7-89b4-4d5c-90cb-cf2e5a0c9fbd")
            },
            new PatientMedicationPrescription
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                MedicationId = Guid.Parse("3d69e605-c5e4-42f0-9f00-18f3a12f54ed"),
                DoctorId = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"),
                StartDate = new DateTime(2024, 02, 01),
                EndDate = new DateTime(2024, 08, 01),
                Notes = "Control de glucosa en paciente con diabetes tipo 2.",
                Status = true,
                MedicalConsultationId = Guid.Parse("7a8b5e23-3f6b-4315-bf4e-8b7e1a5b15bc")
            }
        );
    }
}