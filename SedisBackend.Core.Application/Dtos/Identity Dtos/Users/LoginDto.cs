using System.ComponentModel.DataAnnotations;


namespace SedisBackend.Core.Application.Dtos.Identity_Dtos.Users
{
    public class LoginDto
    {

        [Required(ErrorMessage = "Debe colocar el nombre del usuario")]
        [DataType(DataType.Text)]
        public string Email { get; set; }



        [Required(ErrorMessage = "Debe colocar una contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public string? Error { get; set; }
        public bool HasError { get; set; }
    }
}
