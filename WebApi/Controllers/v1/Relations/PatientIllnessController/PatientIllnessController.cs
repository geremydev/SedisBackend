using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
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
    public async Task<IActionResult> Get(Guid PatientId)
    {
        return Ok(await _sender.Send(new GetPatientIllnesessQuery(PatientId, false)));
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
    public async Task<IActionResult> Put(Guid PatientId, Guid IllnessId, [FromBody] PatientIllnessForUpdateDto PatientIllnesss)
    {
        var command = new UpdatePatientIllnessCommand(PatientId, IllnessId, PatientIllnesss, true);

        await _sender.Send(command);
        return Ok();
    }

    /*[HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientIllnessForUpdateDto))]
    public async Task<IActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<PatientIllnessForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        var command = new PatchPatientIllnessCommand(id, true, patchDoc);
        var (PatientIllnesssToPatch, _) = await _sender.Send(command);

        return Ok(PatientIllnesssToPatch);
    }*/

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid PatientId, Guid IllnessId)
    {
        var notification = new DeletePatientIllnessCommand(PatientId, IllnessId, true);
        await _sender.Send(notification);
        return NoContent();
    }
}
