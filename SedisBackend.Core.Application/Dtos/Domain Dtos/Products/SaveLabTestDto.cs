using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Products
{
    public class SaveLabTestDto
    {
        public int Id { get; set; }

        // Name of the lab test
        public string TestName { get; set; }

        // Code of the lab test (LOINC, CPT, etc.)
        public string TestCode { get; set; }

    }
}
