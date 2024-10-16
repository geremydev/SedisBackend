using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Discapacity_Condition;
using SedisBackend.Core.Domain.Users.Patients;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Discapacity_Condition
{
    public class BasePatientDiscapacityDto
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public Guid DiscapacityId { get; set; }
        public Discapacity Discapacity { get; set; }
        // Fecha de diagnóstico (opcional)
        public DateTime? DiagnosisDate { get; set; }

        // Nivel de severidad (leve, moderada, severa) (opcional)
        public string Severity { get; set; }
    }
}
