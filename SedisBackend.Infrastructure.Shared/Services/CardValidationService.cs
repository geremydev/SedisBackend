using Newtonsoft.Json;
using SedisBackend.Core.Domain.DTO.Shared;
using SedisBackend.Core.Domain.Interfaces.Services.Shared;

namespace SedisBackend.Infrastructure.Shared.Services;

public class CardValidationService : ICardValidationService
{
    private Uri _baseAddress { get; set; }
    private HttpClient _httpClient { get; set; } = new();
    public CardValidationService()
    {
        _baseAddress = new Uri("https://api.digital.gob.do/v3/cedulas/");
        _httpClient.BaseAddress = _baseAddress;
    }

    public async Task<IdVerificationDto> VerifyCardId(string CardId)
    {
        HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + $"{CardId}/validate").Result;
        IdVerificationDto jsonData = JsonConvert.DeserializeObject<IdVerificationDto>(response.Content.ReadAsStringAsync().Result);
        return jsonData;
    }
}
