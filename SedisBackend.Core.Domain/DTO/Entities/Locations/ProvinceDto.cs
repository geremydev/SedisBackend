﻿namespace SedisBackend.Core.Domain.DTO.Entities.Locations;

public record ProvinceDto
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string Identifier { get; set; }
    public string RegionCode { get; set; }
}