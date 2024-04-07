using SedisBackend.Core.Domain.Prescriptions;
using System.Text.Json.Serialization;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Prescriptions
{
    public class SaveLabTestPrescriptionDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int ClinicalHistoryId { get; set; }
        public int LabTestId { get; set; }
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
        public string Status { get; set; } // Usamos el enum LabTestStatus
        public DateTime PerformedDate { get; set; }
        public string ResultUrl { get; set; }
    }
}
