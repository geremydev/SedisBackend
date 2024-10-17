namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Health_Centers
{
    public class SaveHealthCenterDto
    {
        public string Name { get; set; }
        public Guid LocationId { get; set; }
        public string HealthCenterCategory { get; set; } // Usando enum HealthCenterCategory 
    }
}
