using System.ComponentModel.DataAnnotations;

namespace SedisBackend.Core.Domain.DTO.Identity.Authentication;

public class AuthenticationRequest
{
    [Required(ErrorMessage = "Identification is required")]
    public string? CardId { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
}
