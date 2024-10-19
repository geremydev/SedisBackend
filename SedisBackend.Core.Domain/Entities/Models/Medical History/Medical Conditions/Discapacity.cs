using SedisBackend.Core.Domain.Entities;
using SedisBackend.Core.Domain.Enums;

namespace SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Discapacity_Condition;

public class Discapacity : IBaseEntity
{
    public Guid Id { get; set; }

    // Tipo de discapacidad (física, sensorial, intelectual, etc.)
    public DiscapacityType Type { get; set; }

    // Descripción de la discapacidad
    public string Description { get; set; }
}
