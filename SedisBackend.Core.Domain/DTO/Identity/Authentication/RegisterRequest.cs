using Microsoft.AspNetCore.Http;
using SedisBackend.Core.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SedisBackend.Core.Domain.DTO.Identity.Authentication;

public class RegisterRequest
{
    [Required(ErrorMessage = "User name is required")]
    public string? UserName { get; set; }

    [Required(ErrorMessage = "First name is required")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "ConfirmPassword is required")]
    public string? ConfirmPassword { get; set; }

    [Required(ErrorMessage = "CardId is required")]
    public string? CardId { get; set; }

    [JsonIgnore]
    public IFormFile? FormFile { get; set; }
    public string? ImageUrl { get; set; }
    public bool Status { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime Birthdate { get; set; }
    public SexEnum Sex { get; set; }
}
