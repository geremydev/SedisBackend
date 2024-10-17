namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Discapacity_Condition
{
    public class SavePatientDiscapacityDto
    {
        public Guid PatientId { get; set; }
        public Guid DiscapacityId { get; set; }
        // Fecha de diagnóstico (opcional)
        public DateTime? DiagnosisDate { get; set; }

        // Nivel de severidad (leve, moderada, severa) (opcional)
        public string Severity { get; set; }
    }
}
