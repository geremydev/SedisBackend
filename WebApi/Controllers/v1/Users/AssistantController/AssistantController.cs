
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.AssistantHandlers;
using SedisBackend.Core.Domain.DTO.Entities.Users.Assistants;
using SedisBackend.Core.Domain.Interfaces.Loggers;

namespace WebApi.Controllers.v1.Users.AssistantController;

//[Authorize(Roles = "Admin")]
[ApiVersion("1.0")]
public class AssistantController : BaseApiController
{
    private readonly ISender _sender;
    private readonly ILoggerManager _loggerManager;

    public AssistantController(ISender sender, ILoggerManager loggerManager)
    {
        _sender = sender;
        _loggerManager = loggerManager;
    }

    [HttpGet(Name = "GetAllAssistants")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AssistantDto))]
    public async Task<IActionResult> Get()
    {
        return Ok(await _sender.Send(new GetAssistantsQuery(false)));
    }

    [HttpGet("{id:guid}", Name = "GetAssistantById")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AssistantDto))]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _sender.Send(new GetAssistantQuery(id, false)));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    ////[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Post([FromBody] AssistantForCreationDto assistant)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = new CreateAssistantCommand(assistant);
        await _sender.Send(command);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AssistantForUpdateDto))]
    ////[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Put(Guid id, [FromBody] AssistantForUpdateDto assistant)
    {
        var command = new UpdateAssistantCommand(id, assistant, true);

        await _sender.Send(command);
        return Ok();
    }

    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AssistantForUpdateDto))]
    public async Task<IActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<AssistantForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        var command = new PatchAssistantCommand(id, true, patchDoc);
        var (assistantToPatch, _) = await _sender.Send(command);

        return Ok(assistantToPatch);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var notification = new DeleteAssistantCommand(id, true);
        await _sender.Send(notification);
        return NoContent();
    }
}
