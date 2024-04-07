using System.Text.Json.Serialization;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Allergies
{
    public class SaveAllergyDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Allergen { get; set; }
    }
}
