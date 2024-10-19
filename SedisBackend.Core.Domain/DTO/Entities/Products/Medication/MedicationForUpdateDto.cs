using SedisBackend.Core.Domain.Enums;

namespace SedisBackend.Core.Domain.DTO.Entities.Products.Medication;

public record MedicationForUpdateDto
{
    public string Name { get; set; }
    public DosageForm DosageForm { get; set; }
    public string ActiveIngredient { get; set; }
    public decimal Concentration { get; set; }
    public MedicationUnitOfMeasure UnitOfMeasurement { get; set; }
    public MedicationAdministrationRoute RouteOfAdministration { get; set; }
    public string Indications { get; set; }
    public string Contraindications { get; set; }
    public string Precautions { get; set; }
    public string SideEffects { get; set; }
    public string DrugInteractions { get; set; }
    public MedicationPresentation Presentation { get; set; }
    public string ImageUrl { get; set; }
    public string NationalCode { get; set; }

    public MedicationForUpdateDto()
    {

    }
}
