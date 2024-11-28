using SedisBackend.Core.Domain.Entities.Models.Products;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;

namespace SedisBackend.Core.Domain.DTO.Entities.PatientLabTestPrescription;
public class PatientLabTestPrescriptionForCreationDto
{
    public Guid MedicalConsultationId { get; set; }
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public Guid LabTestId { get; set; }
    public DateTime? PerformedDate { get; set; }
    public DateTime? InvalidationDate { get; set; }
    public string Status { get; set; } // Usamos el enum AppointmentStatus
    public Guid LabTechId { get; set; }
    public string ResultUrl { get; set; }
}
