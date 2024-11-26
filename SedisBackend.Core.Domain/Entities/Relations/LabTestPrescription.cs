using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;

namespace SedisBackend.Core.Domain.Entities.Relations;

public class AppointmentPrescription : IBaseEntity
{
    public Guid Id { get; set; }
    public Guid ClinicalHistoryId { get; set; }
    public MedicalConsultation ClinicalHistory { get; set; }
    public Guid AppointmentId { get; set; }
    public Appointment Appointment { get; set; }
    public Guid PrescriptionId { get; set; }
    public Prescription Prescription { get; set; }
    public string Status { get; set; } // Usamos el enum AppointmentStatus
    public DateTime PerformedDate { get; set; }
    public string ResultUrl { get; set; }
}
