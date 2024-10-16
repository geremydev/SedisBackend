using SedisBackend.Core.Domain.Users.Patients;

namespace SedisBackend.Core.Domain.Medical_History.Family_History
{
    public class FamilyHistory
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public string? RelativeId { get; set; } // Nullable por si el familiar no existe
        public Patient? Relative { get; set; }
        public string Condition { get; set; }
        public string Relationship { get; set; } // Usamos FamilyTie para darle valor.
    }
}
