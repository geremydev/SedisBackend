using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientIllnessHandlers;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.PatientIllness;
using SedisBackend.Core.Domain.Interfaces.Loggers;
using WebApi.Controllers;

[ApiVersion("1.0")]
public class PatientIllnessController : BaseApiController
{
    private readonly ISender _sender;
    private readonly ILoggerManager _loggerManager;

    public PatientIllnessController(ISender sender, ILoggerManager loggerManager)
    {
        _sender = sender;
        _loggerManager = loggerManager;
    }

    [HttpGet("{id:guid}", Name = "GetPatientIllnessById")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientIllnessDto))]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _sender.Send(new GetPatientIllnesessQuery(id, false)));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    ////[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Post([FromBody] PatientIllnessForCreationDto PatientIllnesss)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = new CreatePatientIllnessCommand(PatientIllnesss);
        await _sender.Send(command);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientIllnessForUpdateDto))]
    ////[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Put(Guid id, [FromBody] PatientIllnessForUpdateDto PatientIllnesss)
    {
        var command = new UpdatePatientIllnessCommand(id, PatientIllnesss, true);

        await _sender.Send(command);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid patientId, Guid IllnessId)
    {
        var notification = new DeletePatientIllnessCommand(patientId, IllnessId, true);
        await _sender.Send(notification);
        return NoContent();
    }
}
