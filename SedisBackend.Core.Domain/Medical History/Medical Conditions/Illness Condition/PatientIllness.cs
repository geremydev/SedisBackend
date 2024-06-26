﻿using SedisBackend.Core.Domain.Users.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Illness_Condition
{
    public class PatientIllness
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int IllnessId { get; set; }
        public Illness Illness { get; set; }   
        public string DocumentURL { get; set; } //Diagnóstico Médico y así
        public DateTime? DiagnosisDate { get; set; }
        
        // Fecha de alta (opcional)
        public DateTime? DischargeDate { get; set; }
        // Estado actual de la enfermedad (activa, inactiva, en remisión)
        public string Status { get; set; }
        public string Notes { get; set; }
    }
}
