using SedisBackend.Core.Domain.Users.Patients;

namespace SedisBackend.Core.Domain.Medical_History.Family_History
{
    public class FamilyHistory
    {
        public int Id { get; set; }
        public string PatientId { get; set; }
        public Patient Patient { get; set; }
        public string? RelativeId { get; set; } // Nullable por si el familiar no existe
        public string Condition { get; set; } 
        public string Relationship { get; set; } // Usamos FamilyTie para darle valor.
    }
}
