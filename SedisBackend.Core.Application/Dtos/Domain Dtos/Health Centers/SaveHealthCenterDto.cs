﻿using SedisBackend.Core.Application.Dtos.Domain_Dtos.Locations;
using System.Text.Json.Serialization;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Health_Centers
{
    public class SaveHealthCenterDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public SaveLocationDto LocationId { get; set; }
        public string HealthCenterCategory { get; set; } // Usando enum HealthCenterCategory 
    }
}