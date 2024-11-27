using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;

namespace SedisBackend.Core.Domain.Entities.Relations;

public class AppointmentPrescription : IBaseEntity
{
    public Guid Id { get; set; }
    public Guid MedicalconsultationId { get; set; }
    public MedicalConsultation Medicalconsultation { get; set; }
    public Guid AppointmentId { get; set; }
    public Appointment Appointment { get; set; }
    public string Status { get; set; } // Usamos el enum AppointmentStatus
    public DateTime PerformedDate { get; set; }
    public string ResultUrl { get; set; }
}
