namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Locations
{
    public class BaseLocationDto
    {
        public Guid Id { get; set; }
        public Guid EntityId { get; set; }
        public string EntityType { get; set; } //Doctor, Paciente, Hospital, Clinica
        public Guid MunicipalityId { get; set; }
        public Guid ProvinceId { get; set; }
        public string? PostalCode { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
    }
}
