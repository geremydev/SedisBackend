using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SedisBackend.Core.Domain.Interfaces.Loggers;

namespace WebApi.Controllers.v1.Relations.HealthCenterServicesController;

//[Authorize(Roles = "Admin")]
[ApiVersion("1.0")]
public class HealthCenterServicesController : BaseApiController
{
    private readonly ISender _sender;
    private readonly ILoggerManager _loggerManager;

    public HealthCenterServicesController(ISender sender, ILoggerManager loggerManager)
    {
        _sender = sender;
        _loggerManager = loggerManager;
    }

    [HttpGet(Name = "GetAllHealthCenterServices")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<HealthCenterServicesDto>))]
    public async Task<IActionResult> Get()
    {
        return Ok(await _sender.Send(new GetHealthCenterServicesQuery(false)));
    }

    [HttpGet("{id:guid}", Name = "GetHealthCenterServiceById")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HealthCenterServicesDto))]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _sender.Send(new GetHealthCenterServiceQuery(id, false)));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    ////[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Post([FromBody] HealthCenterServicesForCreationDto healthCenterServices)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = new CreateHealthCenterServicesCommand(healthCenterServices);
        await _sender.Send(command);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HealthCenterServicesForUpdateDto))]
    ////[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Put(Guid id, [FromBody] HealthCenterServicesForUpdateDto healthCenterServices)
    {
        var command = new UpdateHealthCenterServicesCommand(id, healthCenterServices, true);

        await _sender.Send(command);
        return Ok();
    }

    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HealthCenterServicesForUpdateDto))]
    public async Task<IActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<HealthCenterServicesForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        var command = new PatchHealthCenterServicesCommand(id, true, patchDoc);
        var (HealthCenterServicesToPatch, _) = await _sender.Send(command);

        return Ok(HealthCenterServicesToPatch);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var notification = new DeleteHealthCenterServicesCommand(id, true);
        await _sender.Send(notification);
        return NoContent();
    }
}
