//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using SedisBackend.Core.Application.CommandQueryHandlers.IllnessHandlers;
//using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Illness_Condition;
//using SedisBackend.Core.Domain.Interfaces.Loggers;

//namespace WebApi.Controllers.v1.Domain.IllnessController;
//public class PatientIllnessController : BaseApiController
//{
//    private readonly ISender _sender;
//    private readonly ILoggerManager _loggerManager;

//    public PatientIllnessController(ISender sender, ILoggerManager loggerManager)
//    {
//        _sender = sender;
//        _loggerManager = loggerManager;
//    }

//    [HttpGet(Name = "GetAllPatientIllnesses")]
//    [ProducesResponseType(StatusCodes.Status404NotFound)]
//    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientIllnessDto))]
//    public async Task<IActionResult> Get(Guid id)
//    {
//        return Ok(await _sender.Send(new GetPatientIllnessesQuery(id, false)));
//    }

//    [HttpGet("{id:guid}", Name = "GetPatientIllnessById")]
//    [ProducesResponseType(StatusCodes.Status404NotFound)]
//    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientIllnessDto))]
//    public async Task<IActionResult> GetById(Guid id)
//    {
//        return Ok(await _sender.Send(new GetPatientIllnessesByIdQuery(id, false)));
//    }

//    [HttpPost]
//    [ProducesResponseType(StatusCodes.Status204NoContent)]
//    [ProducesResponseType(StatusCodes.Status400BadRequest)]
//    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//    ////[Authorize(Roles = "Admin")]
//    public async Task<IActionResult> Post([FromBody] PatientIllnessForCreationDto patientIllness)
//    {
//        if (!ModelState.IsValid)
//        {
//            return BadRequest(ModelState);
//        }

//        var command = new CreatePatientIllnessCommand(patientIllness);
//        await _sender.Send(command);
//        return NoContent();
//    }

//    [HttpPut("{id:guid}")]
//    [ProducesResponseType(StatusCodes.Status400BadRequest)]
//    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientIllnessForUpdateDto))]
//    ////[Authorize(Roles = "Admin")]
//    public async Task<IActionResult> Put(Guid id, [FromBody] PatientIllnessForUpdateDto illness)
//    {
//        var command = new UpdatePatientIllnessCommand(id, illness, true);

//        await _sender.Send(command);
//        return Ok();
//    }
//}
