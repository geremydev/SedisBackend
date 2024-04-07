using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Discapacity_Condition;
using SedisBackend.Core.Domain.Users.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Discapacity_Condition
{
    public class SavePatientDiscapacityDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DiscapacityId { get; set; }
        // Fecha de diagnóstico (opcional)
        public DateTime? DiagnosisDate { get; set; }

        // Nivel de severidad (leve, moderada, severa) (opcional)
        public string Severity { get; set; }
    }
}
