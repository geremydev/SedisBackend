using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SedisBackend.Core.Domain.Entities.Users;

public class User : IdentityUser<Guid>
{
    [MaxLength(11)]
    public string CardId { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool Status { get; set; }
    public DateTime Birthdate { get; set; }
    public SexEnum Sex { get; set; }
    public string? ImageUrl { get; set; }
}
