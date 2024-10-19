using SedisBackend.Core.Domain.Enums;

namespace SedisBackend.Core.Domain.Entities.Models.Products;

public class Medication : IBaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DosageForm DosageForm { get; set; } // Usando el Enum DosageForm
    public string ActiveIngredient { get; set; }
    public decimal Concentration { get; set; }
    public MedicationUnitOfMeasure UnitOfMeasurement { get; set; } // Considerar un mejor formato de escritura.
    public MedicationAdministrationRoute RouteOfAdministration { get; set; }
    public string Indications { get; set; }
    public string Contraindications { get; set; }
    public string Precautions { get; set; }
    public string SideEffects { get; set; }
    public string DrugInteractions { get; set; }
    public MedicationPresentation Presentation { get; set; } // Detalles de presentacion (e.g., Pastillas, Jarabe, etc.)
    public string ImageUrl { get; set; }
    public string NationalCode { get; set; }
}
