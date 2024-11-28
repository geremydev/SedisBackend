﻿using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SedisBackend.Core.Domain.Interfaces.Loggers;

namespace WebApi.Controllers.v1.Relations.PatientHealthInsuranceController;

//[Authorize(Roles = "Admin")]
[ApiVersion("1.0")]
public class PatientHealthInsuranceController : BaseApiController
{
    private readonly ISender _sender;
    private readonly ILoggerManager _loggerManager;

    public PatientHealthInsuranceController(ISender sender, ILoggerManager loggerManager)
    {
        _sender = sender;
        _loggerManager = loggerManager;
    }

    [HttpGet(Name = "GetAllPatientHealthInsurances")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PatientHealthInsurancesDto>))]
    public async Task<IActionResult> Get()
    {
        return Ok(await _sender.Send(new GetPatientHealthInsurancesQuery(false)));
    }

    [HttpGet("{id:guid}", Name = "GetPatientHealthInsuranceById")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientHealthInsurancesDto))]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _sender.Send(new GetPatientHealthInsuranceQuery(id, false)));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    ////[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Post([FromBody] PatientHealthInsuranceForCreationDto PatientHealthInsurances)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = new CreatePatientHealthInsuranceCommand(PatientHealthInsurances);
        await _sender.Send(command);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientHealthInsuranceForUpdateDto))]
    ////[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Put(Guid id, [FromBody] PatientHealthInsuranceForUpdateDto PatientHealthInsurances)
    {
        var command = new UpdatePatientHealthInsuranceCommand(id, PatientHealthInsurances, true);

        await _sender.Send(command);
        return Ok();
    }

    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientHealthInsuranceForUpdateDto))]
    public async Task<IActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<PatientHealthInsuranceForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        var command = new PatchPatientHealthInsuranceCommand(id, true, patchDoc);
        var (PatientHealthInsurancesToPatch, _) = await _sender.Send(command);

        return Ok(PatientHealthInsurancesToPatch);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var notification = new DeletePatientHealthInsuranceCommand(id, true);
        await _sender.Send(notification);
        return NoContent();
    }
}
