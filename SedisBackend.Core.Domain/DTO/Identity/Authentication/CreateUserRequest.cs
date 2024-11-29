using System.ComponentModel.DataAnnotations;

namespace SedisBackend.Core.Domain.DTO.Identity.Authentication;
public class CreateUserRequest
{
    [Required(ErrorMessage = "UserName is required")]
    public string UserName { get; set; }    

    [Required (ErrorMessage = "First Name is required")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last Name is required")]

    public string LastName { get; set; }
    [Required(ErrorMessage = "Card Id is required")]

    public string CardId { get; set; }
    public bool Status { get; set; } = true;
    [Required(ErrorMessage = "Birthdate is required")]

    public DateTime Birthdate { get; set; }
    [Required(ErrorMessage = "Sex is required")]

    public string Sex { get; set; }
    [Required(ErrorMessage = "Email is required")]

    public string Email { get; set; }
    [Required(ErrorMessage = "Password is required")]

    public string Password { get; set; }
    [Required(ErrorMessage = "PhoneNumber is required")]

    public string PhoneNumber { get; set; }
    public string ImageUrl { get; set; }
}
