﻿using SedisBackend.Core.Domain.Medical_History.Allergies;
using SedisBackend.Core.Domain.Users.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Allergies
{
    public class SavePatientAllergyDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int AllergyId { get; set; }
        public string AllergicReaction { get; set; }
        public DateTime? DiagnosisDate { get; set; }
    }
}