using SedisBackend.Core.Domain.Entities;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Enums;

namespace SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Discapacity_Condition;

public class Discapacity : IBaseEntity
{
    public Guid Id { get; set; }
    public string IcdCode { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<PatientDiscapacity> PatientDiscapacities { get; set; }
}
