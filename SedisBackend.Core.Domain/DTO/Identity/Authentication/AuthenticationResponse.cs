namespace SedisBackend.Core.Domain.DTO.Identity.Authentication;

public class AuthenticationResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public List<string> Roles { get; set; }
    public bool Succeeded { get; set; }
    public string? Error { get; set; }
    public string? JWToken { get; set; }
    public string? RefreshToken { get; set; }
}

public class MinimalAuthenticationResponse
{
    public string AccessToken { get; set; }
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public List<string> Roles { get; set; }
    public bool Succeeded { get; set; }
    public string? Error { get; set; }
}

public class FailedResponse
{
    public bool Succeeded { get; set; }
    public string? Error { get; set; }
}