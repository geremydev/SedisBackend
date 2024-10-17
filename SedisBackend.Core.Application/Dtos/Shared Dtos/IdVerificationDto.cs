namespace SedisBackend.Core.Application.Dtos.Shared_Dtos
{
    public class IdVerificationDto
    {
        public bool valid { get; set; }
        public string message { get; set; }
        public DateTime timestamp { get; set; }
        public string error { get; set; }
    }
}
