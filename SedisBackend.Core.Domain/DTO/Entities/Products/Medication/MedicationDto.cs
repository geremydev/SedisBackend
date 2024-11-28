namespace SedisBackend.Core.Domain.DTO.Entities.Products.Medication;

public record MedicationDto
{
    public Guid Id { get; set; }
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
    public bool Status { get; set; }

}
