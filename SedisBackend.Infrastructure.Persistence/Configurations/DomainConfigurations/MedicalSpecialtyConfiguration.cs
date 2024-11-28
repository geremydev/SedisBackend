using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Infrastructure.Persistence.Configurations.DomainConfigurations;

public class MedicalSpecialtyConfiguration : IEntityTypeConfiguration<MedicalSpecialty>
{
    public void Configure(EntityTypeBuilder<MedicalSpecialty> builder)
    {
        builder.HasData
        (
            new MedicalSpecialty
            {
                Id = Guid.Parse("b1c2d3e4-f5a6-6789-0123-abcdef456789"),
                Name = "Pediatría",
                Description = "Dedicada a la atención médica de bebés, niños y adolescentes.",
                Doctors = new List<DoctorMedicalSpecialty>()
            },
            new MedicalSpecialty
            {
                Id = Guid.Parse("c2d3e4f5-a6b7-8901-2345-abcdef678901"),
                Name = "Ortopedia",
                Description = "Se especializa en el diagnóstico y tratamiento del sistema musculoesquelético.",
                Doctors = new List<DoctorMedicalSpecialty>()
            },
            new MedicalSpecialty
            {
                Id = Guid.Parse("d3e4f5a6-b7c8-9012-3456-abcdef789012"),
                Name = "Dermatología",
                Description = "Se centra en el diagnóstico y tratamiento de afecciones de la piel.",
                Doctors = new List<DoctorMedicalSpecialty>()
            },
            new MedicalSpecialty
            {
                Id = Guid.Parse("e4f5a6b7-c8d9-0123-4567-abcdef890123"),
                Name = "Oncología",
                Description = "Especializado en el diagnóstico y tratamiento del cáncer.",
                Doctors = new List<DoctorMedicalSpecialty>()
            },
            new MedicalSpecialty
            {
                Id = Guid.Parse("f5a6b7c8-d9e0-1234-5678-abcdef901234"),
                Name = "Ginecología",
                Description = "Dedicada a la salud y enfermedades del aparato reproductor femenino.",
                Doctors = new List<DoctorMedicalSpecialty>()
            },
            new MedicalSpecialty
            {
                Id = Guid.Parse("a6b7c8d9-e0f1-2345-6789-abcdef012345"),
                Name = "Psiquiatría",
                Description = "Se centra en el diagnóstico, tratamiento y prevención de trastornos mentales, emocionales y del comportamiento.",
                Doctors = new List<DoctorMedicalSpecialty>()
            },
            new MedicalSpecialty
            {
                Id = Guid.Parse("b7c8d9e0-f1a2-3456-7890-abcdef123456"),
                Name = "Oftalmología",
                Description = "Se especializa en el cuidado médico y quirúrgico de los ojos y la visión.",
                Doctors = new List<DoctorMedicalSpecialty>()
            },
            new MedicalSpecialty
            {
                Id = Guid.Parse("c8d9e0f1-a2b3-4567-8901-abcdef234567"),
                Name = "Endocrinología",
                Description = "Dedicada al diagnóstico y tratamiento de trastornos relacionados con las hormonas.",
                Doctors = new List<DoctorMedicalSpecialty>()
            },
            new MedicalSpecialty
            {
                Id = Guid.Parse("d9e0f1a2-b3c4-5678-9012-abcdef345678"),
                Name = "Neumología",
                Description = "Se centra en el diagnóstico y tratamiento de los trastornos del sistema respiratorio.",
                Doctors = new List<DoctorMedicalSpecialty>()
            },
            new MedicalSpecialty
            {
                Id = Guid.Parse("e0f1a2b3-c4d5-6789-0123-abcdef456789"),
                Name = "Gastroenterología",
                Description = "Se especializa en el diagnóstico y tratamiento del aparato digestivo.",
                Doctors = new List<DoctorMedicalSpecialty>()
            }
        );
    }
}
