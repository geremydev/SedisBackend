namespace SedisBackend.Core.Domain.Locations
{
    public class Location : IBaseEntity
    {
        public Guid Id { get; set; }
        public Guid EntityId { get; set; }
        public string EntityType { get; set; } //Doctor, Paciente, Hospital, Clinica
        public Guid RegionId { get; set; }
        public Guid ProvinceId { get; set; }
        public Guid MunicipalityId { get; set; }
        public string? PostalCode { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
    }
}
