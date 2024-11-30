namespace SedisBackend.Core.Domain.DTO.Entities.Users.Patients;

public class PatientForUpdateDto
{
    public string BloodType { get; set; }
    public string? BloodTypeLabResultURl { get; set; }
    public decimal Height { get; set; }
    public decimal Weight { get; set; }
    public string? EmergencyContactName { get; set; }
    public string? EmergencyContactPhone { get; set; }
    public Guid? PrimaryCarePhysicianId { get; set; }
    public bool Status { get; set; }
}
