using SedisBackend.Core.Domain.Medical_History.Clinical_History;

namespace SedisBackend.Core.Domain.Products
{
    public class LabTest
    {
        public int Id { get; set; }
        public int ClinicalHistoryId { get; set; } 
        public ClinicalHistory ClinicalHistory { get; set; } 
        public string Status { get; set; } // Usamos el enum LabTestStatus
        public string TestType { get; set; } 
        public DateTime PerformedDate { get; set; } 
        public string ResultUrl { get; set; }
    }
}
