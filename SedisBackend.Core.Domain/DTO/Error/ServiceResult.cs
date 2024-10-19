namespace SedisBackend.Core.Domain.DTO.Error;

public class ServiceResult
{
    public bool Succeeded { get; set; } = false;
    public List<CustomError> Errors { get; set; } = new List<CustomError> { };
}

public class CustomError
{
    public string Code { get; set; }
    public string Description { get; set; }
}