namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Family_History
{
    public class SaveFamilyHistoryDto
    {
        public Guid PatientId { get; set; }
        public string? RelativeId { get; set; } // Nullable por si el familiar no existe
        public string Condition { get; set; }
        public string Relationship { get; set; } // Relation with the relative (uncle, cousin...)
    }
}
