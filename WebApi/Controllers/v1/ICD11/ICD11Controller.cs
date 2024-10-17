using Microsoft.AspNetCore.Mvc;
using SedisBackend.Core.Application.Interfaces.Services;
using SedisBackend.WebApi.Controllers.v1;

namespace WebApi.Controllers.v1.ICD11
{
    [ApiVersion("1.0")]
    public class ICD11Controller : BaseApiController
    {
        private readonly IServiceManager _service;
        public ICD11Controller(IServiceManager service) => _service = service;

        // GET: api/icd11/search?q={query}
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Query parameter 'id' is required.");
            }
            else if (id.Length != 9)
            {
                return BadRequest("Query parameter 'id' must be a valid entity id.");
            }

            // Define los encabezados necesarios
            var headers = new Dictionary<string, string>
            {
                { "API-Version", "v2" },
                { "Accept-Language", "en" },
                { "accept", "application/json" }
            };

            try
            {
                // Llamar al servicio para buscar en ICD11
                var response = await _service.ICD11.SearchByIdAsync(id, headers);

                if (response != null) return Ok(response);

                return NotFound(new
                {
                    error = $"Entity with id '{id}' couldn't be found.",
                });
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine(ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
