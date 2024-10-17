using Newtonsoft.Json.Linq;
using SedisBackend.Core.Application.Dtos.ICD11;
using SedisBackend.Core.Application.Interfaces.Repositories.ICD11;

namespace SedisBackend.Infrastructure.Persistence.Repositories.ICD11
{
    public class ICD11Repository : IICD11Repository
    {
        private readonly HttpClient _httpClient;

        public ICD11Repository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:8382");
        }

        public async Task<ICDDestinationEntity> SearchByIdAsync(string id, IDictionary<string, string> headers)
        {
            // Construct the URL for the entity by ID
            var url = $"/icd/entity/{id}";

            try
            {
                // Configure headers
                foreach (var header in headers)
                {
                    _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
                }

                // Send the GET request
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                //response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode) {
                    // Read and parse the response content
                    var content = await response.Content.ReadAsStringAsync();
                    ICDDestinationEntity entityInfo = ParseEntityInfo(content, id);

                    return entityInfo;
                }

                return null;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex);
                throw new Exception("Error while making the request to the ICD11 API.", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("An unexpected error occurred.", ex);
            }
        }

        private ICDDestinationEntity ParseEntityInfo(string jsonResponse, string id)
        {
            var jObject = JObject.Parse(jsonResponse);

            // Extract necessary fields
            var fullUrl = jObject["@id"]?.ToString();
            var title = jObject["title"]?["@value"]?.ToString();
            var definition = jObject["definition"]?["@value"]?.ToString();
            var longDefinition = jObject["longDefinition"]?["@value"]?.ToString();
            var spanishBrowserUrl = $"https://icd.who.int/browse/2024-01/foundation/es#{id}";

            // Return the entity with required properties
            return new ICDDestinationEntity
            {
                Id = id,
                FullUrl = fullUrl,
                SpanishBrowserUrl = spanishBrowserUrl,
                Title = title,
                Definition = definition,
                LongDefinition = longDefinition
            };
        }

        #region SearchQuery (No es necesario)
        //public async Task<ICDDestinationEntity> SearchAsync(string query, IDictionary<string, string> headers, object body = null)
        //{
        //    // Crear la URL para la búsqueda
        //    var url = $"/icd/entity/id?q={Uri.EscapeDataString(query)}";

        //    try
        //    {
        //        // Configurar los encabezados
        //        foreach (var header in headers)
        //        {
        //            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
        //        }

        //        HttpResponseMessage response;

        //        // Determinar el método HTTP (GET o POST)
        //        //if (body != null)
        //        //{
        //        //    response = await _httpClient.PostAsJsonAsync(url, body);
        //        //}
        //        //else
        //        //{
        //        //    response = await _httpClient.GetAsync(url);
        //        //}

        //        response = await _httpClient.GetAsync(url);

        //        response.EnsureSuccessStatusCode();

        //        var content = await response.Content.ReadAsStringAsync();

        //        string jsonResponse = content;
        //        ICDDestinationEntity firstEntityInfo = GetFirstEntityInfo(jsonResponse);

        //        if (firstEntityInfo != null)
        //        {
        //            Console.WriteLine($"ID: {firstEntityInfo.Id}");
        //            return firstEntityInfo;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        // Manejar errores de solicitud
        //        Console.WriteLine(ex);
        //        throw new Exception("Error al realizar la solicitud a la API de ICD11.", ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejar otros errores
        //        Console.WriteLine(ex);
        //        throw new Exception("Ocurrió un error inesperado.", ex);
        //    }
        //}

        //public ICDDestinationEntity GetFirstEntityInfo(string jsonResponse)
        //{
        //    // Parse the JSON response directly to access only the needed properties
        //    var jObject = Newtonsoft.Json.Linq.JObject.Parse(jsonResponse);
        //    var destinationEntities = jObject["destinationEntities"];

        //    // Check if there are any destination entities
        //    if (destinationEntities != null && destinationEntities.HasValues)
        //    {
        //        var firstEntity = destinationEntities.First;

        //        return new ICDDestinationEntity
        //        {
        //            Id = firstEntity["id"]?.ToString(),
        //            Title = firstEntity["title"]?.ToString()
        //        };
        //    }

        //    return null; // Or throw an exception if preferred
        //}
        #endregion
    }
}
