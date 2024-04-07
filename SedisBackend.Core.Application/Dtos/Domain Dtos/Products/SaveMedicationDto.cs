using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Products
{
    public class SaveMedicationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DosageForm { get; set; } // Usando el Enum DosageForm
        public string ActiveIngredient { get; set; }
        public decimal Concentration { get; set; }
        public string UnitOfMeasurement { get; set; } // Considerar un mejor formato de escritura.
        public string RouteOfAdministration { get; set; }
        public string Indications { get; set; }
        public string Contraindications { get; set; }
        public string Precautions { get; set; }
        public string SideEffects { get; set; }
        public string DrugInteractions { get; set; }
        public string Presentation { get; set; } // Detalles de presentacion (e.g., Pastillas, Jarabe, etc.)
        public string ImageUrl { get; set; }
        public string NationalCode { get; set; }
    }
}
