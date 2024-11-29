namespace SedisBackend.Core.Domain.DTO.Entities.Users.Doctors;

public record DoctorForCreationDto 
{
    public Guid UserId { get; set; }
    public Guid HealthCenterId { get; set; }
    public string LicenseNumber { get; set; }
}
