namespace SedisBackend.Core.Domain.DTO.Entities.Users.Doctors;

public record DoctorForUpdateDto : BaseUserForUpdateDto
{
    public string LicenseNumber { get; set; }
}
