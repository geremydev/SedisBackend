using System.ComponentModel.DataAnnotations;

namespace SedisBackend.Core.Domain.DTO.Identity.Authentication;

public record ResetPasswordRequest
{
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Token is required")]
    public string Token { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }

    [Required(ErrorMessage = "ConfirmPassword is required")]
    public string ConfirmPassword { get; set; }
}
