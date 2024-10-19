using SedisBackend.Core.Domain.Enums;

namespace SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Illness_Condition;

public record IllnessDto
{
    public Guid Id { get; set; }

    // Código de la enfermedad (ICD-10, SNOMED CT, etc.)
    public string Code { get; set; } // Codigo en si de esa codificacion especifica
    public IllnessCodeType CodeType { get; set; } // Tipo de codificacion del Code

    // Nombre de la enfermedad
    public string Name { get; set; }

    // Descripción de la enfermedad
    public string Description { get; set; }
}
