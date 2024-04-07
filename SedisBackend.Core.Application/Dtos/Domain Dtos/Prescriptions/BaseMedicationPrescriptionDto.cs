using SedisBackend.Core.Domain.Prescriptions;
using SedisBackend.Core.Domain.Products;
using SedisBackend.Core.Domain.Users.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Prescriptions
{
    public class BaseMedicationPrescriptionDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        //public Patient Patient { get; set; }
        public int MedicationId { get; set; }
        //public Medication Medication { get; set; }
        public int PrescriptionId { get; set; }
        //public Prescription Prescription { get; set; }
        public DateTime? TreatmentStart { get; set; }
        public DateTime? TreatmentEnd { get; set; }
        public string Dosage { get; set; } //Debe estar en un formato estandarizado
        public string Status { get; set; } //Usamos el enum MedicationConsuptionStatus 
    }
}
