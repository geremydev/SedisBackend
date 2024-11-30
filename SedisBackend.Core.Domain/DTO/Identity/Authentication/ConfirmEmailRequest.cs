using System.ComponentModel.DataAnnotations;

namespace SedisBackend.Core.Domain.DTO.Identity.Authentication;
public class ConfirmEmailRequest
{
    [Required(ErrorMessage = "User ID is required.")]
    public string UserId { get; set; }

    [Required(ErrorMessage = "Token is required.")]
    public string Token { get; set; }
}
