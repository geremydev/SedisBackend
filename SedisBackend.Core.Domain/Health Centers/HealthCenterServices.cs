namespace SedisBackend.Core.Domain.Health_Centers
{
    public class HealthCenterServices : IBaseEntity
    {
        public Guid Id { get; set; }
        public Guid HealthCenterId { get; set; }
        public HealthCenter HealthCenter { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
    }
}
