namespace SedisBackend.Core.Domain.DTO.Identity.Authentication;

public class DtoAccount
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string ImageUrl { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public List<string> Roles { get; set; }
    public bool IsVerified { get; set; }
    public bool IsActive { get; set; }
    public bool Succeeded { get; set; }
    public string? Error { get; set; }
}