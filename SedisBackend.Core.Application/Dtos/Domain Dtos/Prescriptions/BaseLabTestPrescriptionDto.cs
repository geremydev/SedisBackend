using SedisBackend.Core.Domain.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Prescriptions;
using SedisBackend.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Prescriptions
{
    public class BaseLabTestPrescriptionDto
    {
        public int Id { get; set; }
        public int ClinicalHistoryId { get; set; }
        public ClinicalHistory ClinicalHistory { get; set; }
        public int LabTestId { get; set; }
        public LabTest LabTest { get; set; }
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
        public string Status { get; set; } // Usamos el enum LabTestStatus
        public DateTime PerformedDate { get; set; }
        public string ResultUrl { get; set; }
    }
}
