namespace SedisBackend.Core.Domain.DTO.Entities.Users.Doctors;

public record DoctorForUpdateDto
{
    public bool Status { get; set; }
    public string LicenseNumber { get; set; }
    public ICollection<Guid> CurrentlyWorkingHealthCenters { get; set; }
}
