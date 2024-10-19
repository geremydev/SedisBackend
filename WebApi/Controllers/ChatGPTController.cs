using Microsoft.AspNetCore.Mvc;
using SedisBackend.Core.Domain.Interfaces.Services.Identity;
using SedisBackend.Core.Domain.Interfaces.Services.Shared;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[SwaggerTag("OpenAI Controller.")]
public class ChatGPTController : ControllerBase
{
    private readonly IChatGPTService _chatGPTService;

    public ChatGPTController(IAuthService authService, ICardValidationService cardValidationService, IChatGPTService chatGPTService)
    {
        _chatGPTService = chatGPTService;
    }

    // Esto debe ser en un endpoint aparte
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
}
