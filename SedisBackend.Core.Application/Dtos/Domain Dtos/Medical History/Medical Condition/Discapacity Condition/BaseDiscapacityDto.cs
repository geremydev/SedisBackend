using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Discapacity_Condition
{
    public class BaseDiscapacityDto
    {
        public int Id { get; set; }

        // Tipo de discapacidad (física, sensorial, intelectual, etc.)
        public string Type { get; set; }

        // Descripción de la discapacidad
        public string Description { get; set; }
    }
}
