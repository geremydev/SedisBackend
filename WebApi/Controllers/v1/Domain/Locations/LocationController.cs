﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Locations;
using SedisBackend.Core.Application.Dtos.Shared_Dtos;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Locations;
using SedisBackend.WebApi.Controllers.v1;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApi.Controllers.v1.Domain.Locations
{
    [ApiVersion("1.0")]
    public class LocationController : BaseApiController
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseLocationDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var locations = await _locationService.GetAllAsync();

                if (locations == null || locations.Count == 0)
                {
                    return NotFound();
                }

                return Ok(locations);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseLocationDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var location = await _locationService.GetByIdAsync(id);

                if (location == null)
                {
                    return NotFound();
                }

                return Ok(location);
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
        public async Task<IActionResult> Post(SaveLocationDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _locationService.AddAsync(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveLocationDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, SaveLocationDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _locationService.UpdateAsync(dto, id);
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
                await _locationService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        /*[HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProvinceDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                Uri baseAddress = new Uri("https://api.digital.gob.do/v1/");
                HttpClient _httpClient = new HttpClient();
                _httpClient.BaseAddress = baseAddress;
                HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/territories/provinces").Result;
                List< ProvinceDto> jsonData = new();
                jsonData = JsonConvert.DeserializeObject<List<ProvinceDto>>(response.Content.ReadAsStringAsync().Result);

                return Ok(jsonData);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }*/

    }
}
