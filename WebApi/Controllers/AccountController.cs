using Microsoft.AspNetCore.Mvc;
using SedisBackend.Core.Application.Dtos.Identity_Dtos.Account;
using SedisBackend.Core.Application.Interfaces.Services;
using SedisBackend.Core.Application.Interfaces.Services.Shared_Services;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Estas son las funcionalidades de Sing Up and Sing In.")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ICardValidationService _cardValidationService;
        private readonly IChatGPTService _chatGPTService;


        public AccountController(IAccountService accountService, ICardValidationService cardValidationService, IChatGPTService chatGPTService)
        {
            _accountService = accountService;
            _cardValidationService = cardValidationService;
            _chatGPTService = chatGPTService;
        }

        [HttpPost("authenticate")]
        [SwaggerOperation(Summary = "El Endpoint de Login",
                          Description = "Aqui van los datos para iniciar sesion (Email, Password).")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _accountService.AuthenticateAsync(request));
        }

        [HttpPost("{query}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(string query)
        {
            try
            {
                var response = _chatGPTService.SendQuery(query);

                if (response.Length == 0)
                {
                    return NotFound();
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("register")]
        [SwaggerOperation(Summary = "El Endpoint de Registro",
                          Description = "Aqui tendras que llenar todos los campos con los datos correspondientes para registrarte en el sistema.")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request, string userRoles)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.RegisterUserAsync(request, origin, userRoles));
        }


        [HttpPost("upgrade-user")]
        [SwaggerOperation(Summary = "El Endpoint de upgrade user",
                          Description = "Aqui tendras que llenar todos los campos con los datos correspondientes para registrarte en el sistema.")]
        public async Task<IActionResult> Update2Doctor(string CardId, Guid HealthCenterId, string Role)
        {
            try
            {
                await _accountService.AddRole(CardId, HealthCenterId, Role);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
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

        [HttpGet("validate-IdCard")]
        [SwaggerOperation(Summary = "Valida si la cédula existe en los servidores de la JCE",
                          Description = "Inserta tu cédula sin guiones.")]
        public async Task<IActionResult> VerifyIdCard(string IdCard)
        {
            return Ok(await _cardValidationService.VerifyCardId(IdCard));
        }
    }
}
