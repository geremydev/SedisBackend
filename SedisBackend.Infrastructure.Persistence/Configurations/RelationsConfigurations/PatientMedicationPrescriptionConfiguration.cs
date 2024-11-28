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
                StartDate = new DateTime(2024, 01, 01),
                EndDate = new DateTime(2024, 06, 01),
                Notes = "Iniciar tratamiento para controlar la glucosa.",
                Status = true
            },
            new PatientMedicationPrescription
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.Parse("d2a432f3-5a3b-47c7-b3f2-71053c1b6f19"),
                MedicationId = Guid.Parse("c3a1a1e3-e2b5-42ac-8b34-358ea7745d6e"),
                StartDate = new DateTime(2024, 03, 01),
                EndDate = new DateTime(2024, 03, 15),
                Notes = "Tratamiento para el dolor abdominal severo y fiebre.",
                Status = true
            },
            new PatientMedicationPrescription
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.Parse("a1b0e3c4-7a5c-4d8d-bab2-12a3fcd7405e"),
                MedicationId = Guid.Parse("f1c839fa-d3f8-433d-b6e3-e8d5296d22d9"),
                StartDate = new DateTime(2024, 02, 15),
                EndDate = new DateTime(2024, 03, 01),
                Notes = "Medicamento para el dolor articular y la inflamación.",
                Status = true
            },
            new PatientMedicationPrescription
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.Parse("eb4d27a8-392b-40fe-b3c3-c3d1d8b1a238"),
                MedicationId = Guid.Parse("4b2c6894-cc7d-4565-bb18-aba013826de7"),
                StartDate = new DateTime(2024, 03, 05),
                EndDate = new DateTime(2024, 06, 05),
                Notes = "Tratamiento para depresión y ansiedad.",
                Status = true
            },
            new PatientMedicationPrescription
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.Parse("c8b5b0d3-01d6-4a93-84fd-d3d48217cc47"),
                MedicationId = Guid.Parse("e4c9b8d4-9a5d-44d3-9be7-85e2e57b73c1"),
                StartDate = new DateTime(2024, 01, 15),
                EndDate = new DateTime(2024, 07, 15),
                Notes = "Tratamiento para hipertensión.",
                Status = true
            },
            new PatientMedicationPrescription
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
                MedicationId = Guid.Parse("a2d1c5b7-8f4e-4a6b-9c3d-5e7a1b2c9f5d"),
                StartDate = new DateTime(2024, 02, 01),
                EndDate = new DateTime(2024, 08, 01),
                Notes = "Control de glucosa en paciente con diabetes tipo 2.",
                Status = true
            }
        );
    }
}