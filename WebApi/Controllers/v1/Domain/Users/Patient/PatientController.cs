using Microsoft.AspNetCore.Mvc;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Patients;
using SedisBackend.Core.Application.Interfaces.Services;
using SedisBackend.WebApi.Controllers.v1;

namespace WebApi.Controllers.v1.Domain.Users.Patient
{
    public class PatientController : BaseApiController
    {
        private readonly IServiceManager _service;
        public PatientController(IServiceManager service) => _service = service;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BasePatientDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var patients = await _service.Patient.GetAllAsync();

                if (patients == null || patients.Count == 0)
                {
                    return NotFound();
                }

                return Ok(patients);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BasePatientDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var patient = await _service.Patient.GetByIdAsync(id);

                if (patient == null)
                {
                    return NotFound();
                }

                return Ok(patient);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetAllWithInclude/{includes}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BasePatientDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Get(string includes)
        {
            try
            {
                var list = includes.Split(",").ToList();
                var patientList = await _service.Patient.GetAllWithIncludeAsync(list);



                if (patientList == null)
                {
                    return NotFound();
                }

                return Ok(patientList);
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
        public async Task<IActionResult> Post(SavePatientDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _service.Patient.AddAsync(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SavePatientDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        ////[Authorize(Roles = "Patient")]
        public async Task<IActionResult> Put(Guid id, SavePatientDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _service.Patient.UpdateAsync(dto, id);
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
                await _service.Patient.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }
}
