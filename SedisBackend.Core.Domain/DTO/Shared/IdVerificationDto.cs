namespace SedisBackend.Core.Domain.DTO.Shared;

public class IdVerificationDto
{
    public bool Valid { get; set; }
    public string Message { get; set; }
    public DateTime Timestamp { get; set; }
    public string Error { get; set; }
}
