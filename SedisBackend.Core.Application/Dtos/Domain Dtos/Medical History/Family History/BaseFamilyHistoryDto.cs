using SedisBackend.Core.Domain.Users.Patients;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Family_History
{
    public class BaseFamilyHistoryDto
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public string? RelativeId { get; set; } // Nullable por si el familiar no existe
        public Patient? Relative { get; set; }
        public string Condition { get; set; }
        public string Relationship { get; set; }
    }
}
