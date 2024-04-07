using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Locations
{
    public class BaseLocationDto
    {
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
