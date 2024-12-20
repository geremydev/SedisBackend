﻿namespace SedisBackend.Core.Domain.DTO.Entities.Users;

public class BaseUserDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CardId { get; set; }
    public bool Status { get; set; }
    public DateTime Birthdate { get; set; }
    public string Sex { get; set; }
    public string PhoneNumber { get; set; }
}
