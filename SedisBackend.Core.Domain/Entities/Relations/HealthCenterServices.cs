using SedisBackend.Core.Domain.Entities.Models;

namespace SedisBackend.Core.Domain.Entities.Relations;

public class HealthCenterServices 
{
    public Guid HealthCenterId { get; set; }
    public HealthCenter HealthCenter { get; set; }
    public Guid ServiceId { get; set; }
    public Service Service { get; set; }
    public DateTime CreationDate { get; set; }
    public bool Status { get; set; }
    public string Description { get; set; }
    public string Department { get; set; }
    //Contact information
    public string PhoneNumber { get; set; }
    public string Email {  get; set; }
    public string Address { get; set; }
    public string Requirements { get; set; }
    public string OperatingHours { get; set; }
    public string Cost { get; set; }
    public string AdditionalInformation { get; set; }
}
