using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Dtos.Shared_Dtos
{
    public class IdVerificationDto
    {
        public bool valid { get; set; }
        public string message { get; set; }
        public DateTime timestamp { get; set; }
        public string error { get; set; }
    }
}
