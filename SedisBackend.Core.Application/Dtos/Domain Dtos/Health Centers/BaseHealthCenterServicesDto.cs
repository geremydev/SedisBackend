using SedisBackend.Core.Domain.Health_Centers;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Health_Centers
{
    public class BaseHealthCenterServicesDto
    {
        public Guid Id { get; set; }
        public Guid HealthCenterId { get; set; }
        public HealthCenter HealthCenter { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
    }
}
