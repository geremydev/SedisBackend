namespace SedisBackend.Core.Domain.DTO.Entities.Users.Doctors;

public class DoctorForCreationDto
{
    public Guid UserId { get; set; }
    public string LicenseNumber { get; set; }
}
