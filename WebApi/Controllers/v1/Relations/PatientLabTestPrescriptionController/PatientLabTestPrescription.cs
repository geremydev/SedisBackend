namespace WebApi.Controllers.v1.Relations.PatientLabTestPrescriptionController;

using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientIllnessHandlers;
using SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientLabTestPrescriptionHandlers;
using SedisBackend.Core.Domain.DTO.Entities.PatientLabTestPrescription;
using SedisBackend.Core.Domain.Interfaces.Loggers;
using WebApi.Controllers;

[ApiVersion("1.0")]
public class PatientLabTestPrescriptionController : BaseApiController
{
    private readonly ISender _sender;
    private readonly ILoggerManager _loggerManager;

    public PatientLabTestPrescriptionController(ISender sender, ILoggerManager loggerManager)
    {
        _sender = sender;
        _loggerManager = loggerManager;
    }

    [HttpGet("{id:guid}", Name = "GetPatientLabTestPrescriptionById")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientLabTestPrescriptionDto))]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _sender.Send(new GetPatientLabTestsQuery(id, false)));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    ////[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Post([FromBody] PatientLabTestPrescriptionForCreationDto PatientLabTestPrescriptions)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = new CreatePatientLabTestPrescriptionCommand(PatientLabTestPrescriptions);
        await _sender.Send(command);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientLabTestPrescriptionForUpdateDto))]
    ////[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Put(Guid PatientId, Guid LabTestId, [FromBody] PatientLabTestPrescriptionForUpdateDto PatientLabTestPrescriptions)
    {
        var command = new UpdatePatientLabTestPrescriptionCommand(PatientId, LabTestId, PatientLabTestPrescriptions, true);

        await _sender.Send(command);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid PatientId, Guid LabTestId)
    {
        var notification = new DeletePatientLabTestPrescriptionCommand(PatientId, LabTestId, true);
        await _sender.Send(notification);
        return NoContent();
    }
}
