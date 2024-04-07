using System.Text.Json.Serialization;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Locations
{
    public class SaveLocationDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int EntityId { get; set; }
        public int StreetId { get; set; }
        public int MunicipalityId { get; set; }
        public int ProvinceId { get; set; }
        public int CountryId { get; set; }
        public string? PostalCode { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
    }
}
