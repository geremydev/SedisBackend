namespace SedisBackend.Core.Application.Dtos.Error
{
    public class ServiceResult
    {
        public bool HasError { get; set; }
        public string Error { get; set; }
        public dynamic Result { get; set; }
    }
}
