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
                Id = Guid.Parse("85bc224a-c53f-41db-97b8-92f703ee4452"),
                PatientId = Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"),
                DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                AppointmentDate = DateTime.Parse("2023-10-15 09:00:00"),
                HealthCenterId = Guid.Parse("85bc224a-c53f-41db-97b8-92f703ee4452"),
                Status = "Active",
                ConsultationRoom = "Room 101",
                MedicalConsultationId = Guid.Parse("5d2e7a36-91e8-4b4a-a769-854fa9d4cb29")
            },
            new Appointment
            {
                Id = Guid.Parse("0c8b4a52-f34c-4a7f-90d2-3c84d8c1d6b1"),
                PatientId = Guid.Parse("e2a4d5b6-3c9a-47bc-8db1-cd327a2f92d6"),
                DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                AppointmentDate = DateTime.Parse("2023-11-01 14:30:00"),
                HealthCenterId = Guid.Parse("deb707b2-50f1-4245-9f8d-12a3b6e74933"),
                Status = "Solicited",
                ConsultationRoom = "Room 102",
                MedicalConsultationId = Guid.Parse("2c4f7b60-71a9-4ea8-82f1-7f3c0dbed832")
            },
            new Appointment
            {
                Id = Guid.Parse("d6c8a3b4-a72f-45df-9143-17c8b3d2fdf0"),
                PatientId = Guid.Parse("b7e1e44d-72c9-4c91-a933-9e4f0e6b5f11"),
                DoctorId = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"),
                AppointmentDate = DateTime.Parse("2023-11-10 10:00:00"),
                HealthCenterId = Guid.Parse("c8b0812e-7205-40ad-a249-fb9e6ae64c37"),
                Status = "Canceled",
                ConsultationRoom = "Room 103",
                MedicalConsultationId = Guid.Parse("8f7319e7-89b4-4d5c-90cb-cf2e5a0c9fbd")
            }
        );
    }
}