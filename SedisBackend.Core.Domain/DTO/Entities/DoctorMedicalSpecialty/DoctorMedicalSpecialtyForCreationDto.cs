namespace SedisBackend.Core.Domain.DTO.Entities.DoctorMedicalSpecialty;
public class DoctorMedicalSpecialtyForCreationDto
{
    public Guid DoctorId { get; set; }
    public Guid MedicalSpecialtyId { get; set; }
    public bool Status { get; set; } = true;
}
