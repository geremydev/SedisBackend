using SedisBackend.Core.Domain.Medical_History.Medical_Conditions;
using SedisBackend.Core.Domain.Users.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Illness_Condition
{
    public class SavePatientIllnessDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int IllnessId { get; set; }
        public string DocumentURL { get; set; } //Diagnóstico Médico y así
        public DateTime? DiagnosisDate { get; set; }

        // Fecha de alta (opcional)
        public DateTime? DischargeDate { get; set; }
        // Estado actual de la enfermedad (activa, inactiva, en remisión)
        public string Status { get; set; }
    }
}
