namespace SedisBackend.Core.Domain.DTO.Entities.Users.Doctors;

public class DoctorForUpdateDto
{
    public bool IsActive { get; set; }
    public string LicenseNumber { get; set; }
    public ICollection<Guid> CurrentlyWorkingHealthCenters { get; set; }
}
