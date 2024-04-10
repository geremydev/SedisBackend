using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Locations
{
    public class ProvinceDto
    {
        public string name { get; set; }
        public string code { get; set; }
        public string identifier { get; set; }
        public string regionCode { get; set; }
    }
}
