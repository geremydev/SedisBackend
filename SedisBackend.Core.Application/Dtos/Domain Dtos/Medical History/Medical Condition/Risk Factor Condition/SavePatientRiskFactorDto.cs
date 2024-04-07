﻿using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Risk_Factor;
using SedisBackend.Core.Domain.Users.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Risk_Factor_Condition
{
    public class SavePatientRiskFactorDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int RiskFactorId { get; set; }
    }
}
