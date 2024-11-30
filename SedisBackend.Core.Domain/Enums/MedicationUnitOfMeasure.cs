namespace SedisBackend.Core.Domain.Enums;

public enum MedicationUnitOfMeasure
{
    Milligram = 1,            // Miligramo (mg)
    Gram = 2,                 // Gramo (g)
    Kilogram = 3,             // Kilogramo (kg)
    Microgram = 4,            // Microgramo (µg)
    Liter = 5,                // Litro (L)
    Milliliter = 6,           // Mililitro (mL)
    Unit = 7,                 // Unidad (U)
    InternationalUnit = 8,    // Unidad Internacional (IU)
    Dose = 9,                 // Dosis (general)
    Tablet = 10,              // Pastilla (general)
    Capsule = 11,             // Cápsula (general)
    Patch = 12,               // Parche (general)
    Spray = 13,               // Spray (general)
    Drops = 14,               // Gotas (general)
    Other = 99                // Otras unidades no especificadas
}
