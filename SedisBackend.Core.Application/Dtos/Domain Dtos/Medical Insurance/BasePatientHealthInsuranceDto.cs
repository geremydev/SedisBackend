using SedisBackend.Core.Domain.Medical_Insurance;
using SedisBackend.Core.Domain.Users.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_Insurance
{
    public class BasePatientHealthInsuranceDto
    {
        public int Id { get; set; }
        public string PolicyNumber { get; set; } //Numero de Poliza
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int HealthInsuranceId { get; set; }
        public HealthInsurance HealthInsurance { get; set; }
    }

}
