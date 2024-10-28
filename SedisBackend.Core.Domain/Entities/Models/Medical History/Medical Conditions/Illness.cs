using SedisBackend.Core.Domain.Entities;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Enums;

namespace SedisBackend.Core.Domain.Medical_History.Medical_Conditions;

public class Illness : IBaseEntity
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public IllnessCodeType CodeType { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<PatientIllness> PatientIllnesses { get; set; }
}
