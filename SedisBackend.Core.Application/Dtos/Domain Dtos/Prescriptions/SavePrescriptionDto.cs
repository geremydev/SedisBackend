using SedisBackend.Core.Domain.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Prescriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Prescriptions
{
    public class SavePrescriptionDto
    {
        public int Id { get; set; }
        public int ClinicalHistoryId { get; set; }
        public string? OtherPrescriptions { get; set; }
        public string? Extra { get; set; } // Special instructions for the medication (nullable)
    }
}
