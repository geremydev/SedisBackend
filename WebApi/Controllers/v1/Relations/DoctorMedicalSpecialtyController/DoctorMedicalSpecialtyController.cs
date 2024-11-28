using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SedisBackend.Core.Domain.Interfaces.Loggers;

namespace WebApi.Controllers.v1.Relations.DoctorMedicalSpecialtyController;

//[Authorize(Roles = "Admin")]
[ApiVersion("1.0")]
public class DoctorMedicalSpecialtyController : BaseApiController
{
    private readonly ISender _sender;
    private readonly ILoggerManager _loggerManager;

    public DoctorMedicalSpecialtyController(ISender sender, ILoggerManager loggerManager)
    {
        _sender = sender;
        _loggerManager = loggerManager;
    }

    [HttpGet(Name = "GetAllDoctorMedicalSpecialties")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DoctorMedicalSpecialtyDto>))]
    public async Task<IActionResult> Get()
    {
        return Ok(await _sender.Send(new GetDoctorMedicalSpecialtiesQuery(false)));
    }

    [HttpGet("{id:guid}", Name = "GetDoctorMedicalSpecialtyById")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DoctorMedicalSpecialtyDto))]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _sender.Send(new GetDoctorMedicalSpecialtyQuery(id, false)));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    ////[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Post([FromBody] DoctorMedicalSpecialtyForCreationDto doctorMedicalSpecialty)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = new CreateDoctorMedicalSpecialtyCommand(doctorMedicalSpecialty);
        await _sender.Send(command);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DoctorMedicalSpecialtyForUpdateDto))]
    ////[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Put(Guid id, [FromBody] DoctorMedicalSpecialtyForUpdateDto doctorMedicalSpecialty)
    {
        var command = new UpdateDoctorMedicalSpecialtyCommand(id, doctorMedicalSpecialty, true);

        await _sender.Send(command);
        return Ok();
    }

    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DoctorMedicalSpecialtyForUpdateDto))]
    public async Task<IActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<DoctorMedicalSpecialtyForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        var command = new PatchDoctorMedicalSpecialtyCommand(id, true, patchDoc);
        var (DoctorMedicalSpecialtyToPatch, _) = await _sender.Send(command);

        return Ok(DoctorMedicalSpecialtyToPatch);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var notification = new DeleteDoctorMedicalSpecialtyCommand(id, true);
        await _sender.Send(notification);
        return NoContent();
    }
}
