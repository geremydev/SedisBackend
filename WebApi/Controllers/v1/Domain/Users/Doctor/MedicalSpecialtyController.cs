using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Doctors;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Patients;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Doctors;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Patients;
using SedisBackend.WebApi.Controllers.v1;

namespace WebApi.Controllers.v1.Domain.Users.Doctor
{
    [ApiVersion("1.0")]
    [ApiController]
    public class MedicalSpecialtyController : BaseApiController
    {
        private readonly IMedicalSpecialtyService _medicalSpecialtyService;

        public MedicalSpecialtyController(IMedicalSpecialtyService medicalSpecialtyService)
        {
            _medicalSpecialtyService = medicalSpecialtyService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseMedicalSpecialtyDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var medicalSpecialties = await _medicalSpecialtyService.GetAllAsync();

                if (medicalSpecialties == null || medicalSpecialties.Count == 0)
                {
                    return NotFound();
                }

                return Ok(medicalSpecialties);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseMedicalSpecialtyDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var medicalSpecialty = await _medicalSpecialtyService.GetByIdAsync(id);

                if (medicalSpecialty == null)
                {
                    return NotFound();
                }

                return Ok(medicalSpecialty);
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(SaveMedicalSpecialityDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _medicalSpecialtyService.AddAsync(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveMedicalSpecialityDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, SaveMedicalSpecialityDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _medicalSpecialtyService.UpdateAsync(dto, id);
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
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _medicalSpecialtyService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
