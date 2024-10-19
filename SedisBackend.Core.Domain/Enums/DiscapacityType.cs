namespace SedisBackend.Core.Domain.Enums;

public enum DiscapacityType // DisabilityType realmente pero bueno
{
    Physical = 1,         // Discapacidades físicas, que afectan la movilidad o el uso de partes del cuerpo.
    Sensory = 2,          // Discapacidades sensoriales, como ceguera, sordera o discapacidad visual/auditiva.
    Intellectual = 3,     // Discapacidad intelectual, que afecta la capacidad de aprendizaje o toma de decisiones.
    MentalHealth = 4,     // Trastornos mentales o psicológicos que afectan la salud mental.
    Neurological = 5,     // Trastornos neurológicos como epilepsia o parálisis cerebral.
    SpeechAndLanguage = 6,// Dificultades en la comunicación, como problemas de lenguaje o habla.
    Developmental = 7,    // Discapacidades del desarrollo, como autismo o síndrome de Down.
    Multiple = 8,         // Discapacidad múltiple, cuando hay una combinación de dos o más discapacidades.
    ChronicIllness = 9,   // Condiciones crónicas que pueden causar discapacidad, como la diabetes o enfermedades cardiovasculares.
    Other = 10            // Otras discapacidades que no encajan en las categorías anteriores.
}
