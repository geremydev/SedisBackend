using Microsoft.AspNetCore.Mvc;
using SedisBackend.Core.Application.Dtos.Identity_Dtos.Account;
using SedisBackend.Core.Application.Interfaces.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Estas son las funcionalidades de Sing Up and Sing In.")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("authenticate")]
        [SwaggerOperation(Summary = "El Endpoint de Login",
                          Description = "Aqui van los datos para iniciar sesion (Email, Password).")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _accountService.AuthenticateAsync(request));
        }

        [HttpPost("register")]
        [SwaggerOperation(Summary = "El Endpoint de Registro",
                          Description = "Aqui tendras que llenar todos los campos con los datos correspondientes para registrarte en el sistema.")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request, string userRoles)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.RegisterUserAsync(request, origin, userRoles));
        }

        [HttpGet("confirm-email")]
        [SwaggerOperation(Summary = "El Endpoint para confirmar tu email.",
                          Description = "Aqui tendras que llenar todos los campos con los datos correspondientes para confirmar tu cuenta.")]
        public async Task<IActionResult> RegisterAsync([FromQuery] string userId, [FromQuery] string token)
        {
            return Ok(await _accountService.ConfirmAccountAsync(userId, token));
        }


        [HttpPost("forgot-password")]
        [SwaggerOperation(Summary = "El Endpoint por si la contraseña se te olvida",
                          Description = "Aqui tendras que llenar todos los campos con los datos correspondientes para proceder con el paso de ResetPassword.")]
        public async Task<IActionResult> ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.ForgotPassswordAsync(request, origin));
        }


        [HttpPost("reset-password")]
        [SwaggerOperation(Summary = "El Endpoint de cambiar tu contraseña",
                          Description = "Aqui tendras que llenar todos los campos con los datos correspondientes para cambiar la contraseña.")]
        public async Task<IActionResult> ResetPasswordAsync(ResetPasswordRequest request)
        {
            return Ok(await _accountService.ResetPasswordAsync(request));
        }
    }
}
