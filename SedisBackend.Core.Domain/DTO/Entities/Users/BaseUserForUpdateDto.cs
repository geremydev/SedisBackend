namespace SedisBackend.Core.Domain.DTO.Entities.Users;

public class BaseUserForUpdateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CardId { get; set; }
    public bool Status { get; set; }
    public DateTime Birthdate { get; set; }
    public string Sex { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string ImageUrl { get; set; }
}
