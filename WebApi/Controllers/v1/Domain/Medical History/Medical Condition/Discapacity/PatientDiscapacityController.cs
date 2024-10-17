using Microsoft.AspNetCore.Mvc;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Application.Interfaces.Services;
using SedisBackend.WebApi.Controllers.v1;

namespace WebApi.Controllers.v1.Domain.Medical_History.Medical_Condition.Discapacity
{
    [ApiVersion("1.0")]
    public class PatientDiscapacityController : BaseApiController
    {
        private readonly IServiceManager _service;
        public PatientDiscapacityController(IServiceManager service) => _service = service;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BasePatientDiscapacityDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var patientDiscapacities = await _service.PatientDiscapacity.GetAllAsync();

                if (patientDiscapacities == null || patientDiscapacities.Count == 0)
                {
                    return NotFound();
                }

                return Ok(patientDiscapacities);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BasePatientDiscapacityDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var patientDiscapacity = await _service.PatientDiscapacity.GetByIdAsync(id);

                if (patientDiscapacity == null)
                {
                    return NotFound();
                }

                return Ok(patientDiscapacity);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles = "Doctor")]
        public async Task<IActionResult> Post(SavePatientDiscapacityDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _service.PatientDiscapacity.AddAsync(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SavePatientDiscapacityDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles = "Doctor")]
        public async Task<IActionResult> Put(Guid id, SavePatientDiscapacityDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _service.PatientDiscapacity.UpdateAsync(dto, id);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _service.PatientDiscapacity.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
