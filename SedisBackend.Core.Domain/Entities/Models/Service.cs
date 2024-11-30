using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Core.Domain.Entities.Models;
public class Service : IBaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageURL { get; set; }
    public ICollection<HealthCenterServices> HealthCenterServices { get; set; }
}
