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

    /*[HttpGet(Name = "GetAllPatientLabTestPrescriptions")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PatientLabTestPrescriptionDto>))]
    public async Task<IActionResult> Get()
    {
        return Ok(await _sender.Send(new GetPatientLabTestPrescriptionQuery(false)));
    }*/

    [HttpGet("{PatientId:guid}", Name = "GetPatientLabTestPrescriptionByPatientId")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<PatientLabTestPrescriptionDto>))]
    public async Task<IActionResult> Get(Guid PatientId)
    {
        return Ok(await _sender.Send(new GetPatientLabTestsByPatientIdQuery(PatientId, false)));
    }
    
    [HttpGet( Name = "GetPatientLabTestPrescriptionByHealthCenterId")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<PatientLabTestPrescriptionDto>))]
    public async Task<IActionResult> GetByHealthCenter(Guid HealthCenterId)
    {
        return Ok(await _sender.Send(new GetLabTestPrescriptionsByHealthCenterQuery(HealthCenterId, false)));
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
    public async Task<IActionResult> Put(Guid Id, [FromBody] PatientLabTestPrescriptionForUpdateDto PatientLabTestPrescriptions)
    {
        var command = new UpdatePatientLabTestPrescriptionCommand(Id, PatientLabTestPrescriptions, true);

        await _sender.Send(command);
        return Ok();
    }

    /*[HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientLabTestPrescriptionForUpdateDto))]
    public async Task<IActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<PatientLabTestPrescriptionForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        var command = new PatchPatientLabTestPrescriptionCommand(id, true, patchDoc);
        var (PatientLabTestPrescriptionsToPatch, _) = await _sender.Send(command);

        return Ok(PatientLabTestPrescriptionsToPatch);
    }*/

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid Id)
    {
        var notification = new DeletePatientLabTestPrescriptionCommand(Id, true);
        await _sender.Send(notification);
        return NoContent();
    }
}
