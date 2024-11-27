using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;

namespace SedisBackend.Core.Domain.Entities.Models;

public class Prescription : IBaseEntity
{
    public Guid Id { get; set; }
    public Guid MedicalConsultationId { get; set; }
    public MedicalConsultation MedicalConsultation { get; set; } // Navigation property
    public ICollection<MedicationPrescription>? PrescribedMedications { get; set; }
    public ICollection<AppointmentPrescription>? PrescribedAppointments { get; set; }
    public string? OtherPrescriptions { get; set; }
}
