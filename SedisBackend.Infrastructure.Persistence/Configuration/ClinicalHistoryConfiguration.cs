using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;

namespace SedisBackend.Infrastructure.Persistence.Configuration;

public class ClinicalHistoryConfiguration : IEntityTypeConfiguration<ClinicalHistory>
{
    public void Configure(EntityTypeBuilder<ClinicalHistory> builder)
    {
        builder.ToTable("ClinicalHistories");

        builder.HasData
        (
            new ClinicalHistory
            {
                Id = Guid.Parse("c1aaea0c-c739-4125-a7b3-28da602de5a0"),
                PatientId = Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"),
                DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), // Doctor John Doe
                ReasonForVisit = "Routine check-up",
                CurrentHistory = "No significant issues. Patient reports feeling well overall.",
                PhysicalExamination = @"
                        Vital Signs: BP 120/80 mmHg, HR 75 bpm, RR 16 bpm, Temp 36.7°C.
                        Anthropometry: Weight 72 kg, Height 1.75 m, BMI 23.5 kg/m².
                        General: Skin and mucosa appear healthy, no lesions observed.
                        Cardiovascular: Regular rhythm, no murmurs detected.
                        Respiratory: Clear breath sounds, no wheezes or crackles.
                        Abdomen: Soft, non-tender, no masses or organomegaly.
                        Extremities: No edema, peripheral pulses are intact.
                    ",
                Diagnosis = "Hypertension",
                RegisterDate = DateTime.Parse("2021-03-10")
            },
            new ClinicalHistory
            {
                Id = Guid.Parse("47d713da-eb0f-44c8-bd0d-d1882834c81b"),
                PatientId = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
                DoctorId = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), // Doctor Jane Smith
                ReasonForVisit = "Follow-up on medication.",
                CurrentHistory = "Patient reports feeling better with current medication. No new symptoms.",
                PhysicalExamination = @"
                        Vital Signs: BP 140/90 mmHg, HR 82 bpm, RR 18 bpm, Temp 37.1°C.
                        Anthropometry: Weight 80 kg, Height 1.80 m, BMI 24.7 kg/m².
                        General: Skin warm, no cyanosis or jaundice observed.
                        Cardiovascular: Heart sounds normal, no murmurs detected.
                        Respiratory: Lung fields are clear to auscultation.
                        Abdomen: Non-distended, no tenderness, liver and spleen not palpable.
                        Extremities: No cyanosis or clubbing, peripheral pulses present.
                    ",
                Diagnosis = "Diabetes",
                RegisterDate = DateTime.Now
            }
        );
    }
}
