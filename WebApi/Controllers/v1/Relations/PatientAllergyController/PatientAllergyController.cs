
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientAllergyHandlers;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Allergies;
using SedisBackend.Core.Domain.Interfaces.Loggers;

namespace WebApi.Controllers.v1.Relations.PatientAllergyController;

[ApiVersion("1.0")]
public class PatientAllergyController : BaseApiController
{
    private readonly ISender _sender;
    private readonly ILoggerManager _loggerManager;

    public PatientAllergyController(ISender sender, ILoggerManager loggerManager)
    {
        _sender = sender;
        _loggerManager = loggerManager;
    }

    [HttpGet("{patientId:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PatientAllergyDto>))]
    public async Task<IActionResult> Get(Guid PatientId)
    {
        return Ok(await _sender.Send(new GetPatientAllergiesQuery(PatientId, false)));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    ////[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Post([FromBody] PatientAllergyForCreationDto patientAllergy)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = new CreatePatientAllergyCommand(patientAllergy);
        var result = await _sender.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientAllergyForUpdateDto))]
    ////[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Put(Guid id, [FromBody] PatientAllergyForUpdateDto allergy)
    {
        var command = new UpdatePatientAllergyCommand(id, allergy, true);

        await _sender.Send(command);
        return Ok();
    }
}
