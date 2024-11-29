using SedisBackend.Core.Domain.Entities.Models.Products;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;

namespace SedisBackend.Core.Domain.Entities.Relations;

public class PatientLabTestPrescription 
{
    public Guid Id { get; set; }
    public Guid MedicalConsultationId { get; set; }
    public MedicalConsultation MedicalConsultation { get; set; }
    public Guid PatientId { get; set; }
    public Patient? Patient { get; set; }
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public Guid LabTestId { get; set; }
    public LabTest LabTest { get; set; }
    public DateTime? SolicitedDate { get; set; }
    public DateTime? PerformedDate { get; set; }
    public DateTime? InvalidationDate { get; set; }
    public string Status { get; set; } // Usamos el enum AppointmentStatus
    public Guid LabTechId { get; set; }
    public LabTech LabTech { get; set; }
    public string ResultUrl { get; set; }
}
