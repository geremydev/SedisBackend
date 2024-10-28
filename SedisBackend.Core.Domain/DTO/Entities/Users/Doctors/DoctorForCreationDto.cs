namespace SedisBackend.Core.Domain.DTO.Entities.Users.Doctors;

public record DoctorForCreationDto : BaseUserForCreationDto
{
    public string LicenseNumber { get; set; }
}
