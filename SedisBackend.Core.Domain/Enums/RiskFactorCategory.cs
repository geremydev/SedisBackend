namespace SedisBackend.Core.Domain.Enums;

public enum RiskFactorCategory
{
    Lifestyle = 1,       // Factores de riesgo relacionados con el estilo de vida (dieta, ejercicio, fumar, etc.)
    Genetic = 2,         // Factores de riesgo genéticos o hereditarios
    Environmental = 3,   // Factores de riesgo relacionados con el ambiente (exposición a toxinas, contaminación, etc.)
    Behavioral = 4,      // Factores de riesgo relacionados con comportamientos (uso de drogas, alcohol, etc.)
    Physiological = 5,   // Factores de riesgo relacionados con condiciones fisiológicas (hipertensión, obesidad, etc.)
    Socioeconomic = 6,   // Factores de riesgo relacionados con condiciones socioeconómicas (pobreza, acceso a la atención médica)
    Occupational = 7,    // Factores de riesgo relacionados con el trabajo (exposición a riesgos laborales)
    Other = 99           // Otras categorías no especificadas
}
