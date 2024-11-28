namespace SedisBackend.Core.Domain.DTO.Entities.Locations;

public record LocationForUpdateDto
{
    public Guid RegionId { get; set; }
    public Guid MunicipalityId { get; set; }
    public Guid ProvinceId { get; set; }
    public string? PostalCode { get; set; }
    public decimal? Longitude { get; set; }
    public decimal? Latitude { get; set; }
    public bool Status { get; set; }
    public LocationForUpdateDto()
    {

    }
}
