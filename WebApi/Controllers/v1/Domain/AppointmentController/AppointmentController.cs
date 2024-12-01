using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.AppointmentHandlers;
using SedisBackend.Core.Domain.DTO.Entities.Appointments;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Domain.Interfaces.Loggers;

namespace WebApi.Controllers.v1.Domain.AppointmentController;
[ApiVersion("1.0")]
public class AppointmentController : BaseApiController
{
    private readonly ISender _sender;
    private readonly ILoggerManager _loggerManager;

    public AppointmentController(ISender sender, ILoggerManager loggerManager)
    {
        _sender = sender;
        _loggerManager = loggerManager;
    }

    [HttpGet(Name = "GetAllAppointments")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DiscapacityDto))]
    public async Task<IActionResult> Get()
    {
        return Ok(await _sender.Send(new GetAppointmentsQuery(false)));
    }

    [HttpGet("{id:guid}", Name = "GetAppointmentById")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AppointmentDto))]
    public async Task<IActionResult> Get(Guid AppointmentId)
    {
        return Ok(await _sender.Send(new GetAppointmentQuery(AppointmentId, false)));
    }

    [HttpGet("patients/ongoing/{patientId:guid}", Name = "GetPatientOngoingAppointment")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AppointmentDto>))]
    public async Task<IActionResult> GetPatientOngoingAppointment(Guid PatientId)
    {
        return Ok(await _sender.Send(new GetPatientOngoingAppointmentsQuery(PatientId, false)));
    }

    [HttpGet("patients/requested/{patientId:guid}", Name = "GetPatientRequestedAppointments")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AppointmentDto>))]
    public async Task<IActionResult> GetPatientRequestedAppointments(Guid PatientId)
    {
        return Ok(await _sender.Send(new GetPatientRequestedAppointmentsQuery(PatientId, false)));
    }


    [HttpGet("patients/pending/{patientId:guid}", Name = "GetPatientPendingAppointments")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AppointmentDto>))]
    public async Task<IActionResult> GetPatientPendingAppointments(Guid patientId)
    {
        return Ok(await _sender.Send(new GetPatientPendingAppointmentsQuery(patientId, false)));
    }

    [HttpGet("doctors/pending/{doctorId:guid}", Name = "GetDoctorPendingAppointments")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AppointmentDto>))]
    public async Task<IActionResult> GetDoctorPendingAppointments(Guid doctorId)
    {
        return Ok(await _sender.Send(new GetDoctorPendingAppointmentsQuery(doctorId, false)));
    }

    [HttpGet("doctors/completed/{doctorId:guid}", Name = "GetDoctorCompletedAppointments")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AppointmentDto>))]
    public async Task<IActionResult> GetDoctorCompletedAppointments(Guid doctorId)
    {
        return Ok(await _sender.Send(new GetDoctorCompletedAppointmentsQuery(doctorId, false)));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    ////[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Post([FromBody] AppointmentForCreationDto appointment)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = new CreateAppointmentCommand(appointment);
        await _sender.Send(command);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AppointmentForUpdateDto))]
    ////[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Put(Guid id, [FromBody] AppointmentForUpdateDto appointment)
    {
        var command = new UpdateAppointmentCommand(id, appointment, true);

        await _sender.Send(command);
        return Ok();
    }

    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AppointmentForUpdateDto))]
    public async Task<IActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<AppointmentForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        var command = new PatchAppointmentCommand(id, true, patchDoc);
        var (discapacityToPatch, _) = await _sender.Send(command);

        return Ok(discapacityToPatch);
    }

    /*[HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var notification = new DeleteDiscapacityCommand(id, true);
        await _sender.Send(notification);
        return NoContent();
    }*/
}
