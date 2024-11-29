namespace SedisBackend.Core.Domain.DTO.Entities.PatientLabTestPrescription;
public class PatientLabTestPrescriptionDto
{
    public Guid Id { get; set; }
    public Guid MedicalConsultationId { get; set; }
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public Guid LabTestId { get; set; }
    public DateTime? SolicitedDate { get; set; }
    public DateTime? PerformedDate { get; set; }
    public DateTime? InvalidationDate { get; set; }
    public string Status { get; set; } // Usamos el enum AppointmentStatus
    public Guid LabTechId { get; set; }
    public string ResultUrl { get; set; }
}
