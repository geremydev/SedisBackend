using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Entities.Users.Persons;

namespace SedisBackend.Core.Domain.DTO.Entities.DoctorMedicalSpecialty;
public class DoctorMedicalSpecialtyForUpdateDto
{
    public Guid DoctorId { get; set; }
    public Guid MedicalSpecialtyId { get; set; }
    public bool Status { get; set; }
    public DoctorMedicalSpecialtyForUpdateDto() { }
}
