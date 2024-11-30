namespace SedisBackend.Core.Domain.DTO.Entities.Locations;

public class LocationDto
{
    public Guid Id { get; set; }
    //public Guid EntityId { get; set; }
    //public string EntityType { get; set; } // Doctor, Paciente, Hospital, Clinica
    public Guid RegionId { get; set; }
    public Guid MunicipalityId { get; set; }
    public Guid ProvinceId { get; set; }
    public string? PostalCode { get; set; }
    public decimal? Longitude { get; set; }
    public decimal? Latitude { get; set; }
    public bool Status { get; set; }
}
