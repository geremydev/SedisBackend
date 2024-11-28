using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Models;

namespace SedisBackend.Infrastructure.Persistence.Configurations.DomainConfigurations;
internal class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasData
        (
            new Appointment
            {
                Id = Guid.Parse("792b5eb8-35dc-4e11-8d36-bb4b0344f582"),
                PatientId = Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"),
                DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                AppointmentDate = DateTime.Parse("2023-10-15 09:00:00"),
                HealthCenterId = Guid.Parse("a2e5d7b8-f23a-4c56-8a7f-bf30d7c7a9e2"),
                Status = "Completed",
                ConsultationRoom = "Room 101",
                MedicalConsultationId = Guid.Parse("5d2e7a36-91e8-4b4a-a769-854fa9d4cb29")
            },
            new Appointment
            {
                Id = Guid.Parse("0c8b4a52-f34c-4a7f-90d2-3c84d8c1d6b1"),
                PatientId = Guid.Parse("e2a4d5b6-3c9a-47bc-8db1-cd327a2f92d6"),
                DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                AppointmentDate = DateTime.Parse("2023-11-01 14:30:00"),
                HealthCenterId = Guid.Parse("b8e6f3d7-a13b-4c89-8d5c-dc2e9f8a6e74"),
                Status = "Pending",
                ConsultationRoom = "Room 102",
                MedicalConsultationId = Guid.Parse("2c4f7b60-71a9-4ea8-82f1-7f3c0dbed832")
            },
            new Appointment
            {
                Id = Guid.Parse("d6c8a3b4-a72f-45df-9143-17c8b3d2fdf0"),
                PatientId = Guid.Parse("d9a832b8-123a-4c98-baba-6e2a32e94b9e"),
                DoctorId = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"),
                AppointmentDate = DateTime.Parse("2023-11-10 10:00:00"),
                HealthCenterId = Guid.Parse("c5a7b3d8-e32a-4f7a-8d7c-f72d9e8a7b32"),
                Status = "Ongoing",
                ConsultationRoom = "Room 103",
                MedicalConsultationId = Guid.Parse("8f7319e7-89b4-4d5c-90cb-cf2e5a0c9fbd")
            }
        );
    }
}