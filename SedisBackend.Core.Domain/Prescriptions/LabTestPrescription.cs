using SedisBackend.Core.Domain.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Products;

namespace SedisBackend.Core.Domain.Prescriptions
{
    public class LabTestPrescription : IBaseEntity
    {
        public Guid Id { get; set; }
        public Guid ClinicalHistoryId { get; set; }
        public ClinicalHistory ClinicalHistory { get; set; }
        public Guid LabTestId { get; set; }
        public LabTest LabTest { get; set; }
        public Guid PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
        public string Status { get; set; } // Usamos el enum LabTestStatus
        public DateTime PerformedDate { get; set; }
        public string ResultUrl { get; set; }
    }
}
