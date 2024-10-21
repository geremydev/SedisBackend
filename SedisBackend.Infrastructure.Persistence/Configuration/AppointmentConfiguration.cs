using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Enums;

namespace SedisBackend.Infrastructure.Persistence.Configuration;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasData
        (
            new Appointment
            {
                Id = Guid.Parse("826783f5-dd4f-419e-bb2f-4a8307c54b9b"),
                PatientId = Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"),
                DoctorId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), // Doctor John Doe
                AppointmentDate = new DateTime(2024, 11, 10, 14, 30, 0),
                HealthCenterId = Guid.Parse("85bc224a-c53f-41db-97b8-92f703ee4452"),
                AppointmentStatus = AppointmentStatus.Scheduled,
                ConsultationType = ConsultationType.GeneralAppointment,
                ConsultationRoom = "Room 101"
            },
            new Appointment
            {
                Id = Guid.Parse("5f028eff-479b-43dc-9e1b-2e6839c794f8"),
                PatientId = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
                DoctorId = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), // Doctor Jane Smith
                AppointmentDate = new DateTime(2024, 11, 12, 10, 0, 0),
                HealthCenterId = Guid.Parse("57efafa6-1eec-4228-b7c1-ab87fe2097da"),
                AppointmentStatus = AppointmentStatus.Completed,
                ConsultationType = ConsultationType.FollowUpAppointment,
                ConsultationRoom = "Room 202"
            }
        );
    }
}
