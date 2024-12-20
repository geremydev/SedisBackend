﻿using System.ComponentModel.DataAnnotations;

namespace SedisBackend.Core.Domain.DTO.Identity.Users;

public class ResetPasswordDto
{
    [Required(ErrorMessage = "Debe colocar el email")]
    [DataType(DataType.Text)]
    public string Email { get; set; }

    [Required(ErrorMessage = "Debe tener un token")]
    [DataType(DataType.Text)]
    public string Token { get; set; }

    [Required(ErrorMessage = "Debe colocar una contraseña")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Compare(nameof(Password), ErrorMessage = "Las Contraseñas deben coincidir")]
    [Required(ErrorMessage = "Debe colocar el nombre del usuario")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
    public string? Error { get; set; }
    public bool Succeeded { get; set; }
}
