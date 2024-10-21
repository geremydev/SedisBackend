namespace SedisBackend.Core.Domain.DTO.Entities.Users.Doctors;

public record DoctorForCreationDto
{
    public BaseUserForCreationDto User { get; set; }
    public string LicenseNumber { get; set; }
}
