using System.ComponentModel.DataAnnotations;

namespace SedisBackend.Core.Domain.DTO.Identity.Authentication;

public class ForgotPasswordRequest
{
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }
}
