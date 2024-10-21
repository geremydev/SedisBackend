namespace SedisBackend.Core.Domain.DTO.Entities.Products.Medication;

public record MedicationForCreationDto
{
    public string Name { get; set; }
    public string DosageForm { get; set; }
    public string ActiveIngredient { get; set; }
    public decimal Concentration { get; set; }
    public string UnitOfMeasurement { get; set; }
    public string RouteOfAdministration { get; set; }
    public string Indications { get; set; }
    public string Contraindications { get; set; }
    public string Precautions { get; set; }
    public string SideEffects { get; set; }
    public string DrugInteractions { get; set; }
    public string Presentation { get; set; }
    public string ImageUrl { get; set; }
    public string NationalCode { get; set; }
}
