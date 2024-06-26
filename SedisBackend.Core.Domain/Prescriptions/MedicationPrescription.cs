﻿using SedisBackend.Core.Domain.Products;
using SedisBackend.Core.Domain.Users.Patients;

namespace SedisBackend.Core.Domain.Prescriptions
{
    public class MedicationPrescription
    {
        public int Id { get; set; }
        public int  MedicationId { get; set; }
        public Medication Medication { get; set; }
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
        public DateTime? TreatmentStart { get; set; }
        public DateTime? TreatmentEnd { get; set; }
        public string Dosage { get; set; } //Debe estar en un formato estandarizado
        public string Status { get; set; } //Usamos el enum MedicationConsuptionStatus 
    }
}
