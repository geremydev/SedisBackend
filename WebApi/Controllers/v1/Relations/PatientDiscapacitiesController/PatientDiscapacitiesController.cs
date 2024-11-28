using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientDiscapacityHandlers;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.PatientDiscapacity;
using SedisBackend.Core.Domain.Interfaces.Loggers;

namespace WebApi.Controllers.v1.Relations.PatientDiscapacitiesController;

//[Authorize(Roles = "Admin")]
[ApiVersion("1.0")]
public class PatientDiscapacitiesController : BaseApiController
{
    private readonly ISender _sender;
    private readonly ILoggerManager _loggerManager;

    public PatientDiscapacitiesController(ISender sender, ILoggerManager loggerManager)
    {
        _sender = sender;
        _loggerManager = loggerManager;
    }

    [HttpGet("{id:guid}", Name = "GetPatientDiscapacityById")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientDiscapacityDto))]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _sender.Send(new GetPatientDiscapacitiesQuery(id, false)));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    ////[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Post([FromBody] PatientDiscapacityForCreationDto PatientDiscapacities)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = new CreatePatientDiscapacityCommand(PatientDiscapacities);
        await _sender.Send(command);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientDiscapacityForUpdateDto))]
    ////[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Put(Guid id, [FromBody] PatientDiscapacityForUpdateDto PatientDiscapacities)
    {
        var command = new UpdatePatientDiscapacityCommand(id, PatientDiscapacities, true);

        await _sender.Send(command);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid patientId, Guid DiscapacityId)
    {
        var notification = new DeletePatientDiscapacityCommand(patientId, DiscapacityId, true);
        await _sender.Send(notification);
        return NoContent();
    }
}
