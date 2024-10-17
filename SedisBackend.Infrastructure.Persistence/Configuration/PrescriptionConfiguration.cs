using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Prescriptions;

namespace SedisBackend.Infrastructure.Persistence.Configuration
{
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasData
            (
                new Prescription
                {
                    Id = Guid.Parse("3a5d9b2e-8c4a-4f7e-9d1c-3f6b2a7d8e9c"),
                    ClinicalHistoryId = Guid.Parse("c1aaea0c-c739-4125-a7b3-28da602de5a0"),
                    OtherPrescriptions = "Recomendación de ejercicio diario",
                    PrescribedMedications = new List<MedicationPrescription>(),
                    PrescribedLabTests = new List<LabTestPrescription>()
                },
                new Prescription
                {
                    Id = Guid.Parse("2d7a9b5c-1e3a-4b8c-9f7e-5b3d6a1c9e7b"),
                    ClinicalHistoryId = Guid.Parse("47d713da-eb0f-44c8-bd0d-d1882834c81b"),
                    OtherPrescriptions = "Dieta baja en sodio",
                    PrescribedMedications = new List<MedicationPrescription>(),
                    PrescribedLabTests = new List<LabTestPrescription>()
                }
            );
        }
    }
}
