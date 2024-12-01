namespace SedisBackend.Core.Domain.DTO.Entities.HealthCenterService;
public class HealthCenterServiceForCreationDto
{
    public Guid HealthCenterId { get; set; }
    public Guid ServiceId { get; set; }
    public DateTime CreationDate { get; set; }
    public bool Status { get; set; } = true;
    public string Description { get; set; }
    public string Department { get; set; }
    //Contact information
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Requirements { get; set; }
    public string OperatingHours { get; set; }
    public string Cost { get; set; }
    public string Details { get; set; }
}
