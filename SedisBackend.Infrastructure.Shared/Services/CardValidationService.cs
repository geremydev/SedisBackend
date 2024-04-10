using Newtonsoft.Json;
using SedisBackend.Core.Application.Dtos.Shared_Dtos;
using SedisBackend.Core.Application.Interfaces.Services.Shared_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SedisBackend.Infrastructure.Shared.Services
{
    public class CardValidationService : ICardValidationService
    {
        private Uri _baseAddress { get; set; }
        private HttpClient _httpClient { get; set; } = new();
        public CardValidationService() 
        {
            _baseAddress = new Uri("https://api.digital.gob.do/v3/cedulas/");
            _httpClient.BaseAddress = _baseAddress;
        }
        
        public async Task<IdVerificationDto> VerifyCardId(string IdCard)
        {
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + $"{IdCard}/validate").Result;
            IdVerificationDto jsonData = JsonConvert.DeserializeObject<IdVerificationDto>(response.Content.ReadAsStringAsync().Result);
            return jsonData;
        }
    }
}
