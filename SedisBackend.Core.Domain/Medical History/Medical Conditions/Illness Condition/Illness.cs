using SedisBackend.Core.Domain.Users.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Domain.Medical_History.Medical_Conditions
{
    public class Illness
    {
        public int Id { get; set; }

        // Código de la enfermedad (ICD-10, SNOMED CT, etc.)
        public string Code { get; set; }

        // Nombre de la enfermedad
        public string Name { get; set; }

        // Descripción de la enfermedad
        public string Description { get; set; }

    }
}
