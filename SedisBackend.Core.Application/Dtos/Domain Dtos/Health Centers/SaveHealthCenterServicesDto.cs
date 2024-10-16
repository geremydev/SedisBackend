namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Health_Centers
{
    public class SaveHealthCenterServicesDto
    {
        public Guid Id { get; set; }
        public Guid HealthCenterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
    }
}
