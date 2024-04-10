namespace SedisBackend.Core.Domain.Locations
{
    public class Location
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string EntityType { get; set; } //Doctor, Paciente, Hospital, Clinica
        public int RegionId { get; set; }
        public int ProvinceId { get; set; }
        public int MunicipalityId { get; set; }
        public string? PostalCode { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
    }
}
