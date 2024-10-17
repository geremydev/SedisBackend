using Microsoft.AspNetCore.Mvc;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Assistants;
using SedisBackend.Core.Application.Interfaces.Services;
using SedisBackend.WebApi.Controllers.v1;

namespace WebApi.Controllers.v1.Domain.Users.Assistant
{
    [ApiVersion("1.0")]
    public class AssistantController : BaseApiController
    {
        private readonly IServiceManager _service;
        public AssistantController(IServiceManager service) => _service = service;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseAssistantDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var doctors = await _service.Assistant.GetAllAsync();

                if (doctors == null || doctors.Count == 0)
                {
                    return NotFound();
                }

                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseAssistantDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var doctor = await _service.Assistant.GetByIdAsync(id);

                if (doctor == null)
                {
                    return NotFound();
                }

                return Ok(doctor);
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
        public async Task<IActionResult> Post(SaveAssistantDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                // si el idcard del assistant ya existe no se podra postear, solo modificar
                await _service.Assistant.AddAsync(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveAssistantDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Guid id, SaveAssistantDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _service.Assistant.UpdateAsync(dto, id);
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
                await _service.Assistant.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
