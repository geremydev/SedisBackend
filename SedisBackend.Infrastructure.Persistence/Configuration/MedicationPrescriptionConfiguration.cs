using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Prescriptions;

namespace SedisBackend.Infrastructure.Persistence.Configuration
{
    public class MedicationPrescriptionConfiguration : IEntityTypeConfiguration<MedicationPrescription>
    {
        public void Configure(EntityTypeBuilder<MedicationPrescription> builder)
        {
            builder.HasData
            (
                new MedicationPrescription
                {
                    Id = Guid.Parse("c3e2f7a9-1d4b-8f5c-9a6e-2d9b5c3a7f8e"),
                    MedicationId = Guid.Parse("a2d1c5b7-8f4e-4a6b-9c3d-5e7a1b2c9f5d"),
                    PrescriptionId = Guid.Parse("3a5d9b2e-8c4a-4f7e-9d1c-3f6b2a7d8e9c"),
                    TreatmentStart = DateTime.Parse("2023-03-01"),
                    TreatmentEnd = DateTime.Parse("2023-06-01"),
                    Dosage = "500 mg cada 12 horas",
                    Status = "Consuming"
                },
                new MedicationPrescription
                {
                    Id = Guid.Parse("d9f1c3e5-7b6a-4f2c-9a8e-3d5b7a2f8c1e"),
                    MedicationId = Guid.Parse("e6b5a3c7-9d4f-4a8b-7e1c-2d9f1a5b3c6d"),
                    PrescriptionId = Guid.Parse("2d7a9b5c-1e3a-4b8c-9f7e-5b3d6a1c9e7b"),
                    TreatmentStart = DateTime.Parse("2024-01-05"),
                    TreatmentEnd = DateTime.Parse("2024-04-05"),
                    Dosage = "20 mg diario",
                    Status = "Prescribed"
                }
            );
        }
    }
}
