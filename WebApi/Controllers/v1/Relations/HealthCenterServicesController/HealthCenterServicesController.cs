using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.Doctor;
using SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.DoctorMedicalSpecialtyHandlers;
using SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.HealthCenterServiceHandlers;
using SedisBackend.Core.Domain.DTO.Entities.HealthCenterService;
using SedisBackend.Core.Domain.Interfaces.Loggers;

namespace WebApi.Controllers.v1.Relations.HealthCenterServicesController;

//[Authorize(Roles = "Admin")]
[ApiVersion("1.0")]
public class HealthCenterServicesController : BaseApiController
{
    private readonly ISender _sender;
    private readonly ILoggerManager _loggerManager;

    public HealthCenterServicesController(ISender sender, ILoggerManager loggerManager)
    {
        _sender = sender;
        _loggerManager = loggerManager;
    }

    // De momento no hay command para traer todas las entidades, tampoco es necesario
    //[HttpGet(Name = "GetAllHealthCenterServices")]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<HealthCenterServiceDto>))]
    //public async Task<IActionResult> Get()
    //{
    //    return Ok(await _sender.Send(new GetAllHealthCentersServicesQuery(false)));
    //}

    [HttpGet("{id:guid}", Name = "GetHealthCenterServiceById")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HealthCenterServiceDto))]
    public async Task<IActionResult> Get(Guid healthcenterId)
    {
        return Ok(await _sender.Send(new GetAllHealthCentersServicesQuery(healthcenterId, false)));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    ////[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Post([FromBody] HealthCenterServiceForCreationDto healthCenterServices)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = new CreateHealthCenterServiceCommand(healthCenterServices);
        await _sender.Send(command);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HealthCenterServiceForUpdateDto))]
    ////[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Put(Guid HealthCenterId, Guid ServiceId, [FromBody] HealthCenterServiceForUpdateDto healthCenterServices)
    {
        var command = new UpdateHealthCenterServiceCommand(HealthCenterId, ServiceId, healthCenterServices, true);

        await _sender.Send(command);
        return Ok();
    }

    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HealthCenterServiceForUpdateDto))]
    public async Task<IActionResult> Patch(Guid HealthCenterId, Guid ServiceId, [FromBody] JsonPatchDocument<HealthCenterServiceForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        var command = new PatchHealthCenterServiceCommand(HealthCenterId, ServiceId, true, patchDoc);
        var (HealthCenterServicesToPatch, _) = await _sender.Send(command);

        return Ok(HealthCenterServicesToPatch);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid HealthCenterId, Guid ServiceId)
    {
        var notification = new DeleteHealthCenterServiceCommand(HealthCenterId, ServiceId, true);
        await _sender.Send(notification);
        return NoContent();
    }
}
