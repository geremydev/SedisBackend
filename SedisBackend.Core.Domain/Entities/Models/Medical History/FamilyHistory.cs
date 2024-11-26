using SedisBackend.Core.Domain.Entities;
using SedisBackend.Core.Domain.Entities.Users.Persons;

namespace SedisBackend.Core.Domain.Medical_History.Family_History;

public class FamilyHistory : IBaseEntity
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public Guid? RelativeId { get; set; } // Nullable por si el familiar no existe
    public Patient? Relative { get; set; }
    public string Condition { get; set; }
    public string Relationship { get; set; } // Usamos FamilyTie para darle valor.
    public bool Status { get; set; }
}
