using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Dtos.Error
{
    public class ServiceResult
    {
        public bool HasError { get; set; }
        public string Error { get; set; }
        public dynamic Result { get; set; }
    }
}
