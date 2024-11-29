using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;

namespace SedisBackend.Infrastructure.Persistence.Configurations.DomainConfigurations;

public class MedicalConsultationConfiguration : IEntityTypeConfiguration<MedicalConsultation>
{
    public void Configure(EntityTypeBuilder<MedicalConsultation> builder)
    {
        builder.ToTable("ClinicalHistories");

        builder.HasData
        (
            new MedicalConsultation
            {
                Id = Guid.Parse("5d2e7a36-91e8-4b4a-a769-854fa9d4cb29"),
                PatientId = Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"),
                DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                AppointmentId = Guid.Parse("792b5eb8-35dc-4e11-8d36-bb4b0344f582"),
                ReasonForVisit = "Difficulty reading and focusing on objects.",
                CurrentHistory = "Patient reports persistent issues with vision clarity and difficulty reading fine print over the past three months.",
                PhysicalExamination = "Observed squinting during visual acuity tests. Referral to ophthalmology recommended.",
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow,
                Status = "Completed"
            },
            new MedicalConsultation
            {
                Id = Guid.Parse("2c4f7b60-71a9-4ea8-82f1-7f3c0dbed832"),
                PatientId = Guid.Parse("e2a4d5b6-3c9a-47bc-8db1-cd327a2f92d6"),
                DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                AppointmentId = Guid.Parse("0c8b4a52-f34c-4a7f-90d2-3c84d8c1d6b1"),
                ReasonForVisit = "Eye strain during extended screen time.",
                CurrentHistory = "Patient reports mild discomfort and fatigue in the eyes after working on a computer for extended periods.",
                PhysicalExamination = "Visual acuity slightly reduced in low light. Suggested blue light filtering glasses and breaks during screen usage.",
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow,
                Status = "Pending"
            },
            new MedicalConsultation
            {
                Id = Guid.Parse("8f7319e7-89b4-4d5c-90cb-cf2e5a0c9fbd"),
                PatientId = Guid.Parse("d9a832b8-123a-4c98-baba-6e2a32e94b9e"),
                DoctorId = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"),
                AppointmentId = Guid.Parse("d6c8a3b4-a72f-45df-9143-17c8b3d2fdf0"),
                ReasonForVisit = "Hearing difficulties and speech development concerns.",
                CurrentHistory = "Patient reports difficulty hearing in noisy environments. Speech development has been slower than expected.",
                PhysicalExamination = "Hearing tests confirm moderate hearing loss. Advised evaluation for hearing aids and speech therapy.",
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow,
                Status = "Ongoing"
            },
            new MedicalConsultation
            {
                Id = Guid.Parse("3d4e8a71-17a5-45c7-bec6-a7934c0425bc"),
                PatientId = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
                DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                AppointmentId = Guid.Parse("12345678-90ab-cdef-1234-567890abcdef"),
                ReasonForVisit = "Dificultades respiratorias persistentes.",
                CurrentHistory = "Paciente reporta episodios de disnea y fatiga tras actividades leves.",
                PhysicalExamination = "Estertores crepitantes en ambos campos pulmonares.",
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow,
                Status = "Completed"
            },
            new MedicalConsultation
            {
                Id = Guid.Parse("7a8b5e23-3f6b-4315-bf4e-8b7e1a5b15bc"),
                PatientId = Guid.Parse("ea48eb4c-01c4-44d2-a81f-fc9246d2ec20"),
                DoctorId = Guid.Parse("f86a1609-cb84-4d6a-8d8a-8e49b6b9a5b9"),
                AppointmentId = Guid.Parse("09876543-21dc-ba98-7654-3210fedcba98"),
                ReasonForVisit = "Dolor ocular y disminución de visión.",
                CurrentHistory = "Paciente refiere inicio agudo de dolor ocular intenso, acompañado de visión borrosa.",
                PhysicalExamination = "Inflamación severa en cámara anterior, opacidades vítreas observadas.",
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow,
                Status = "Completed",
                Discapacities =  new List<PatientDiscapacity>
                {
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
                }
            }
        );
    }
}
