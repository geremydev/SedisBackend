using System.ComponentModel.DataAnnotations;

namespace SedisBackend.Core.Domain.DTO.Identity.Users;

public class ForgotPasswordDto
{
    [Required(ErrorMessage = "Debe colocar el email")]
    [DataType(DataType.Text)]
    public string Email { get; set; }
    public string? Error { get; set; }
    public bool Succeeded { get; set; }
}
