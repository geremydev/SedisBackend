
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.MedicationCoverageHandlers;
using SedisBackend.Core.Domain.DTO.Entities.Medical_Insurance.MedicationCoverageDTO;
using SedisBackend.Core.Domain.Interfaces.Loggers;

namespace WebApi.Controllers.v1.Relations.MedicationCoverageController;

//[Authorize(Roles = "Admin")]
[ApiVersion("1.0")]
public class MedicationCoverageController : BaseApiController
{
    private readonly ISender _sender;
    private readonly ILoggerManager _loggerManager;

    public MedicationCoverageController(ISender sender, ILoggerManager loggerManager)
    {
        _sender = sender;
        _loggerManager = loggerManager;
    }

    [HttpGet(Name = "GetAllMedicationCoverages")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MedicationCoverageDto>))]
    public async Task<IActionResult> Get()
    {
        return Ok(await _sender.Send(new GetMedicationCoveragesQuery(false)));
    }

    [HttpGet("{id:guid}", Name = "GetMedicationCoverageById")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MedicationCoverageDto))]
    public async Task<IActionResult> Get(Guid MedicationId, Guid HealthInsuranceId)
    {
        return Ok(await _sender.Send(new GetMedicationCoverageQuery(MedicationId, HealthInsuranceId, false)));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    ////[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Post([FromBody] MedicationCoverageForCreationDto medicationcoverage)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = new CreateMedicationCoverageCommand(medicationcoverage);
        await _sender.Send(command);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MedicationCoverageForUpdateDto))]
    ////[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Put(Guid MedicationId, Guid HealthInsuranceId, [FromBody] MedicationCoverageForUpdateDto medicationcoverage)
    {
        var command = new UpdateMedicationCoverageCommand(MedicationId, HealthInsuranceId, medicationcoverage, true);

        await _sender.Send(command);
        return Ok();
    }

    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MedicationCoverageForUpdateDto))]
    public async Task<IActionResult> Patch(Guid MedicationId, Guid HealthInsuranceId, [FromBody] JsonPatchDocument<MedicationCoverageForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        var command = new PatchMedicationCoverageCommand(MedicationId, HealthInsuranceId, true, patchDoc);
        var (medicationcoverageToPatch, _) = await _sender.Send(command);

        return Ok(medicationcoverageToPatch);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid MedicationId, Guid HealthInsuranceId)
    {
        var notification = new DeleteMedicationCoverageCommand(MedicationId, HealthInsuranceId, true);
        await _sender.Send(notification);
        return NoContent();
    }
}
