using SedisBackend.Core.Domain.Users.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Risk_Factor
{
    public class PatientRiskFactor
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int RiskFactorId { get; set; }
        public RiskFactor RiskFactor { get; set; }
    }
}
