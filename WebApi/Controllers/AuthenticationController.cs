using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SedisBackend.Core.Domain.DTO.Identity.Authentication;
using SedisBackend.Core.Domain.Enums;
using SedisBackend.Core.Domain.Interfaces.Services.Identity;
using SedisBackend.Core.Domain.Interfaces.Services.Shared;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Produces("application/json")]
[SwaggerTag("Estas son las funcionalidades de Sign Up y Sign In.")]
public class AuthenticationController : BaseApiController
{
    private readonly IAuthService _authService;
    private readonly ICardValidationService _cardValidationService;
    private readonly IChatGPTService _chatGPTService;

    public AuthenticationController(IAuthService authService, ICardValidationService cardValidationService, IChatGPTService chatGPTService)
    {
        _authService = authService;
        _cardValidationService = cardValidationService;
        _chatGPTService = chatGPTService;
    }

    [HttpPost("login")]
    [SwaggerOperation(Summary = "Login", Description = "Allows a user to log into the system by providing credentials.")]
    public async Task<IActionResult> AuthenticateAsync([FromBody] AuthenticationRequest request)
    {
        var response = await _authService.AuthenticateAsync(request);
        if (response.Succeeded)
        {
            return BadRequest(new FailedResponse
            {
                Error = response.Error,
                Succeeded = true
            });
        }

        // Set refresh token in an HttpOnly cookie
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = true, // Use in production for HTTPS
            SameSite = SameSiteMode.Strict,
            Expires = DateTimeOffset.UtcNow.AddDays(7) // Adjust expiry based on your requirement
        };

        Response.Cookies.Append("RefreshToken", response.RefreshToken, cookieOptions);

        // Return access token in the response body (handled by client-side in memory)
        return Ok(new MinimalAuthenticationResponse
        {
            AccessToken = response.JWToken,
            Id = response.Id,
            UserName = response.UserName,
            Email = response.Email,
            Roles = response.Roles
        });
    }

    [HttpPost("refresh-token")]
    [SwaggerOperation(Summary = "Refresh Token", Description = "Generates a new access token using the refresh token.")]
    public async Task<IActionResult> RefreshToken()
    {
        var refreshToken = Request.Cookies["RefreshToken"];
        if (string.IsNullOrEmpty(refreshToken))
        {
            return Unauthorized(new FailedResponse
            {
                Succeeded = true,
                Error = "No refresh token provided."
            });
        }

        // Access token is assumed to be sent via Authorization header by the client
        var accessToken = Request.Headers["Authorization"].ToString()?.Replace("Bearer ", "");
        if (string.IsNullOrEmpty(accessToken))
        {
            return Unauthorized(new FailedResponse
            {
                Succeeded = true,
                Error = "No access token provided."
            });
        }

        try
        {
            // Refresh the tokens
            var newToken = await _authService.RefreshTokenAsync(accessToken, refreshToken);

            // Set new access token in response
            return Ok(new { AccessToken = newToken });
        }
        catch (SecurityTokenException ex)
        {
            return Unauthorized(ex.Message);
        }
    }

    [HttpPost("register")]
    [SwaggerOperation(Summary = "Registro de usuario",
                          Description = "Registra un nuevo usuario en el sistema completando todos los campos requeridos en el formulario de registro.")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request, [FromQuery] RolesEnum role)
    {
        var origin = Request.Headers["origin"];

        if (!ModelState.IsValid)
        {
            var errors = string.Join(", ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            return BadRequest(new FailedResponse
            {
                Succeeded = true,
                Error = $"Invalid model: {errors}",
            });
        }

        var result = await _authService.RegisterUserAsync(request, origin, role);

        if (result is not null && result.Succeeded)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpPost("upgrade-user")]
    [SwaggerOperation(Summary = "Actualizar rol de usuario",
                      Description = "Actualiza el rol de un usuario existente, transformándolo en el rol especificado. Se deben proporcionar la cédula del usuario, el ID del centro de salud y el nuevo rol.")]
    public async Task<IActionResult> UpgradeUserRights([FromBody] UpgradeUserRequest request)
    {
        try
        {
            await _authService.AddRole(request.CardId, request.HealthCenterId, request.Role);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("confirm-email")]
    [SwaggerOperation(Summary = "Confirmar cuenta de usuario",
                      Description = "Confirma la dirección de correo electrónico del usuario para activar su cuenta, proporcionando el ID de usuario y el token correspondiente.")]
    public async Task<IActionResult> ConfirmEmailAsync([FromQuery] ConfirmEmailRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(await _authService.ConfirmAccountAsync(request.UserId, request.Token));
    }

    [HttpPost("forgot-password")]
    [SwaggerOperation(Summary = "Recuperar contraseña olvidada",
                      Description = "Inicia el proceso para restablecer la contraseña, enviando un enlace de recuperación al correo electrónico registrado.")]
    public async Task<IActionResult> ForgotPasswordAsync([FromQuery] ForgotPasswordRequest request)
    {
        var origin = Request.Headers["origin"];
        return Ok(await _authService.ForgotPassswordAsync(request, origin));
    }

    [HttpPost("reset-password")]
    [SwaggerOperation(Summary = "Restablecer contraseña",
                      Description = "Permite a un usuario restablecer su contraseña proporcionando los nuevos datos requeridos en el formulario.")]
    public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordRequest request)
    {
        return Ok(await _authService.ResetPasswordAsync(request));
    }

    //[Authorize(Roles = "Admin")]
    [HttpGet("validate-CardId/{cedula}", Name = "validate-idcard")]
    [SwaggerOperation(Summary = "Validar cédula de identidad",
                      Description = "Verifica la existencia de la cédula en los registros de la JCE. Inserta la cédula sin guiones.")]
    public async Task<IActionResult> VerifyCardId(string cedula)
    {
        return Ok(await _cardValidationService.VerifyCardId(cedula));
    }
}
