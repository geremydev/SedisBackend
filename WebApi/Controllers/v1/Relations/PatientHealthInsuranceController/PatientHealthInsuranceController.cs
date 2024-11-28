using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientHealthInsuranceHandlers;
using SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientIllnessHandlers;
using SedisBackend.Core.Domain.DTO.Entities.PatientHealthInsurance;
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

    [HttpGet("{id:guid}", Name = "GetPatientHealthInsuranceById")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientHealthInsuranceDto))]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _sender.Send(new GetPatientHealthInsurancesQuery(id, false)));
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
