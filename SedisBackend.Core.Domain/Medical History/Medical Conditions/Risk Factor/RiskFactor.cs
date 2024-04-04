using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Risk_Factor
{
    public class RiskFactor
    {
        public int Id { get; set; }
        public string Code { get; set; } //SNOMED CT

        // Description of the risk factor
        public string Description { get; set; }

        // Category of the risk factor (lifestyle, genetic, environmental, etc.)
        public string Category { get; set; }

        // Assessment level of the risk factor (low, moderate, high)
        public string AssessmentLevel { get; set; }
    }
}
