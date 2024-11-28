using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Entities.Users.Persons;

namespace SedisBackend.Core.Domain.DTO.Entities.Medical_History.Clinical_History;

public class MedicalConsultationDto
{
    public Guid Id { get; set; } //Unique cause there can exist multiple consultation between one patient and a doctor
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public Guid AppointmentId { get; set; }
    public string ReasonForVisit { get; set; }
    public string CurrentHistory { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public string Status { get; set; }
}
