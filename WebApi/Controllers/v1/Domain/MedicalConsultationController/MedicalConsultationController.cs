using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.ClinicalHistoryHandlers;
using SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.MedicalConsultationHandlers;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Interfaces.Loggers;

namespace WebApi.Controllers.v1.Domain.MedicalConsultationController;

[ApiVersion("1.0")]
public class MedicalConsultationController : BaseApiController
{
    private readonly ISender _sender;
    private readonly ILoggerManager _loggerManager;

    public MedicalConsultationController(ISender sender, ILoggerManager loggerManager)
    {
        _sender = sender;
        _loggerManager = loggerManager;
    }

    [HttpGet(Name = "GetAllMedicalConsultations")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MedicalConsultationDto))]
    public async Task<IActionResult> Get()
    {
        return Ok(await _sender.Send(new GetMedicalConsultationsQuery(false)));
    }

    [HttpGet("{id:guid}", Name = "GetMedicalConsultationById")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MedicalConsultationDto))]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _sender.Send(new GetMedicalConsultationQuery(id, false)));
    }

    [HttpGet("doctor/{doctorId:guid}", Name = "GetMedicalConsultationByDoctorId")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MedicalConsultationDto>))]
    public async Task<IActionResult> GetByDoctorId(Guid doctorId)
    {
        return Ok(await _sender.Send(new GetMedicalConsultationByDoctorQuery(doctorId, false)));
    }

    [HttpGet("patient/{patientId:guid}", Name = "GetMedicalConsultationByPatientId")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MedicalConsultationDto>))]
    public async Task<IActionResult> GetByPatientId(Guid patientId)
    {
        return Ok(await _sender.Send(new GetMedicalConsultationByPatientQuery(patientId, false)));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    ////[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Post([FromBody] MedicalConsultationForCreationDto MedicalConsultation)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = new CreateMedicalConsultationCommand(MedicalConsultation);
        await _sender.Send(command);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MedicalConsultationForUpdateDto))]
    ////[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Put(Guid id, [FromBody] MedicalConsultationForUpdateDto MedicalConsultation)
    {
        var command = new UpdateMedicalConsultationCommand(id, MedicalConsultation, true);

        await _sender.Send(command);
        return Ok();
    }

    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MedicalConsultationForUpdateDto))]
    public async Task<IActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<MedicalConsultationForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        var command = new PatchMedicalConsultationCommand(id, true, patchDoc);
        var (MedicalConsultationToPatch, _) = await _sender.Send(command);

        return Ok(MedicalConsultationToPatch);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var notification = new DeleteMedicalConsultationCommand(id, true);
        await _sender.Send(notification);
        return NoContent();
    }
}