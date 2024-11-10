using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using SedisBackend.Core.Domain.DTO.Identity.Authentication;
using SedisBackend.Core.Domain.Enums;
using SedisBackend.Core.Domain.Interfaces.Services.Identity;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
[ApiVersion("1.0")]
public class UserManagementController : ControllerBase
{
    private readonly IAuthService _authService;

    public UserManagementController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("roles/{role}/change-status")]
    [SwaggerOperation(Summary = "Cambiar estado de rol",
        Description = "Activa o inactiva un rol específico del usuario")]
    public async Task<IActionResult> ChangeRoleStatus(
        [FromRoute] RolesEnum role,
        [FromBody] ChangeRoleStatusRequest request)
    {
        var result = await _authService.ChangeRoleStatus(request.CardId, role, request.IsActive);
        return result.Succeeded ? NoContent() : BadRequest(result.Errors);
    }

    [HttpPost("upgrade-user")]
    [SwaggerOperation(Summary = "Agregar rol a usuario",
        Description = "Agrega un nuevo rol al usuario manteniendo el rol paciente")]
    public async Task<IActionResult> UpgradeUser([FromBody] UpgradeUserRequest request)
    {
        var result = await _authService.AddRole(request.CardId, request.HealthCenterId, request.Role);
        return result.Succeeded ? NoContent() : BadRequest(result.Errors);
    }

    [HttpDelete("roles/{role}")]
    [SwaggerOperation(Summary = "Remover rol de usuario",
        Description = "Remueve un rol específico del usuario")]
    public async Task<IActionResult> RemoveRole(
        [FromRoute] RolesEnum role,
        [FromQuery] string cardId)
    {
        var result = await _authService.RemoveRole(cardId, role);
        return result.Succeeded ? NoContent() : BadRequest(result.Errors);
    }
}