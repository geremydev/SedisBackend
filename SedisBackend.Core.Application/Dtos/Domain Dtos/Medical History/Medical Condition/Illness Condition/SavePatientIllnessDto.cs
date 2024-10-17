namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Illness_Condition
{
    public class SavePatientIllnessDto
    {
        public Guid PatientId { get; set; }
        public Guid IllnessId { get; set; }
        public string DocumentURL { get; set; } //Diagnóstico Médico y así
        public DateTime? DiagnosisDate { get; set; }

        // Fecha de alta (opcional)
        public DateTime? DischargeDate { get; set; }
        // Estado actual de la enfermedad (activa, inactiva, en remisión)
        public string Status { get; set; }
    }
}
