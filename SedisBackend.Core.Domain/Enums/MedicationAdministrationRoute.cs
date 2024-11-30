namespace SedisBackend.Core.Domain.Enums;

public enum MedicationAdministrationRoute
{
    Oral = 1,                   // Vía oral
    Intravenous = 2,            // Vía intravenosa
    Intramuscular = 3,          // Vía intramuscular
    Subcutaneous = 4,           // Vía subcutánea
    Topical = 5,                // Vía tópica
    Inhalation = 6,             // Vía inhalatoria
    Rectal = 7,                 // Vía rectal
    Vaginal = 8,                // Vía vaginal
    Transdermal = 9,            // Vía transdérmica (parches)
    Ophthalmic = 10,            // Vía oftálmica (gotas para los ojos)
    Otic = 11,                  // Vía ótica (gotas para los oídos)
    Nasal = 12,                 // Vía nasal (sprays nasales)
    Intranasal = 13,            // Vía intranasal (administración en las fosas nasales)
    Other = 99                  // Otras vías de administración no especificadas
}
