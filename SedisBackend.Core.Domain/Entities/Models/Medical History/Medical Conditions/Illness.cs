using SedisBackend.Core.Domain.Entities;
using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Core.Domain.Medical_History.Medical_Conditions;

public class Illness : IBaseEntity
{
    public Guid Id { get; set; }
    public string IcdCode { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<PatientIllness> PatientIllnesses { get; set; }
}
