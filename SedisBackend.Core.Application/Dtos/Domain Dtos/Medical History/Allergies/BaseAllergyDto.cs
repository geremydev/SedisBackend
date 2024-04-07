using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Allergies
{
    public class BaseAllergyDto
    {
        public int Id { get; set; }
        public string Allergen { get; set; }
    }
}
