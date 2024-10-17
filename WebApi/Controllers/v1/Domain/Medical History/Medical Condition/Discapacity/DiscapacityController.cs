using Microsoft.AspNetCore.Mvc;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Application.Interfaces.Services;
using SedisBackend.WebApi.Controllers.v1;

namespace WebApi.Controllers.v1.Domain.Medical_History.Medical_Condition.Discapacity
{
    [ApiVersion("1.0")]
    ////[Authorize(Roles = "Admin")]
    public class DiscapacityController : BaseApiController
    {
        private readonly IServiceManager _service;
        public DiscapacityController(IServiceManager service) => _service = service;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseDiscapacityDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var discapacities = await _service.Discapacity.GetAllAsync();

                if (discapacities == null || discapacities.Count == 0)
                {
                    return NotFound();
                }

                return Ok(discapacities);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseDiscapacityDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var discapacity = await _service.Discapacity.GetByIdAsync(id);

                if (discapacity == null)
                {
                    return NotFound();
                }

                return Ok(discapacity);
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
        public async Task<IActionResult> Post(SaveDiscapacityDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _service.Discapacity.AddAsync(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveDiscapacityDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Guid id, SaveDiscapacityDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _service.Discapacity.UpdateAsync(dto, id);
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
                await _service.Discapacity.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
