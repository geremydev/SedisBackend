namespace SedisBackend.Core.Domain.Enums;

public enum IllnessCodeType
{
    ICD10 = 1,        // Clasificación Internacional de Enfermedades, 10ª Revisión (ICD-10)
    ICD11 = 2,        // Clasificación Internacional de Enfermedades, 11ª Revisión (ICD-11)
    SNOMED_CT = 3,    // SNOMED Clinical Terms (SNOMED CT)
    LOINC = 4,        // Logical Observation Identifiers Names and Codes (LOINC)
    DSM5 = 5,         // Manual Diagnóstico y Estadístico de los Trastornos Mentales (DSM-5)
    OMIM = 6,         // Online Mendelian Inheritance in Man (OMIM)
    MeSH = 7,         // Medical Subject Headings (MeSH)
    Other = 99        // Otros sistemas de codificación no listados
}
