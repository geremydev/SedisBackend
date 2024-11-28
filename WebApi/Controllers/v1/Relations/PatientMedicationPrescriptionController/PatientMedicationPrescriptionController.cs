using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientIllnessHandlers;
using SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientMedicationPrescriptionHandlers;
using SedisBackend.Core.Domain.DTO.Entities.PatientMedicationPrescription;
using SedisBackend.Core.Domain.Interfaces.Loggers;

namespace WebApi.Controllers.v1.Relations.PatientMedicationPrescriptionController;

[ApiVersion("1.0")]
public class PatientMedicationPrescriptionController : BaseApiController
{
    private readonly ISender _sender;
    private readonly ILoggerManager _loggerManager;

    public PatientMedicationPrescriptionController(ISender sender, ILoggerManager loggerManager)
    {
        _sender = sender;
        _loggerManager = loggerManager;
    }

    [HttpGet("{id:guid}", Name = "GetPatientMedicationPrescriptionById")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientMedicationPrescriptionDto))]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _sender.Send(new GetPatientMedicationsQuery(id, false)));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    ////[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Post([FromBody] PatientMedicationPrescriptionForCreationDto PatientMedicationPrescriptions)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = new CreatePatientMedicationPrescriptionCommand(PatientMedicationPrescriptions);
        await _sender.Send(command);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientMedicationPrescriptionForUpdateDto))]
    ////[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Put(Guid id, [FromBody] PatientMedicationPrescriptionForUpdateDto PatientMedicationPrescriptions)
    {
        var command = new UpdatePatientMedicationPrescriptionCommand(id, PatientMedicationPrescriptions, true);

        await _sender.Send(command);
        return Ok();
    }

    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientMedicationPrescriptionForUpdateDto))]
    public async Task<IActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<PatientMedicationPrescriptionForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        var command = new PatchPatientMedicationPrescriptionCommand(id, true, patchDoc);
        var (PatientMedicationPrescriptionsToPatch, _) = await _sender.Send(command);

        return Ok(PatientMedicationPrescriptionsToPatch);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var notification = new DeletePatientMedicationPrescriptionCommand(id, true);
        await _sender.Send(notification);
        return NoContent();
    }
}