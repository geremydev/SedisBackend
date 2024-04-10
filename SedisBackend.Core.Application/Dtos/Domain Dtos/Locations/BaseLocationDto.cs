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
        public string EntityType { get; set; } //Doctor, Paciente, Hospital, Clinica
        public int MunicipalityId { get; set; }
        public int ProvinceId { get; set; }
        public string? PostalCode { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
    }
}
