using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions;

namespace SedisBackend.Core.Domain.Entities.Relations;

public class PatientIllness 
{
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public Guid IllnessId { get; set; }
    public Illness Illness { get; set; }
    public string DocumentURL { get; set; } //Diagnóstico Médico y así
    public DateTime? DiagnosisDate { get; set; }

    // Fecha de alta (opcional)
    public DateTime? DischargeDate { get; set; }
    // Estado actual de la enfermedad (activa, inactiva, en remisión)
    public string Status { get; set; }
    public string Notes { get; set; }
}
