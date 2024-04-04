using SedisBackend.Core.Domain.Users.Patients;

namespace SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Discapacity_Condition
{
    public class PatientDiscapacity
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DiscapacityId { get; set; }
        public Discapacity Discapacity { get; set; }
        // Fecha de diagnóstico (opcional)
        public DateTime? DiagnosisDate { get; set; }

        // Nivel de severidad (leve, moderada, severa) (opcional)
        public string Severity { get; set; }
    }
}
