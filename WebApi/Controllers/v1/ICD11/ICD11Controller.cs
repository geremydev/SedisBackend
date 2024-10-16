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
        public async Task<IActionResult> Search([FromQuery] string q)
        {
            if (string.IsNullOrWhiteSpace(q))
            {
                return BadRequest("Query parameter 'q' is required.");
            }

            // Define los encabezados necesarios
            var headers = new Dictionary<string, string>
            {
                { "API-Version", "v2" },  // Cambia a la versión que necesites
                { "Accept-Language", "en" } // Cambia a tu idioma preferido
            };

            try
            {
                // Llamar al servicio para buscar en ICD11
                var response = await _service.ICD11.SearchAsync(q, headers);
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
