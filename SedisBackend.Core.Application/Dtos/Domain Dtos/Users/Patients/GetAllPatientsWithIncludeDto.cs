using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Patients
{
    public class GetAllPatientsWithIncludeDto
    {
        public List<string> Includes { get; set; }
    }
}
