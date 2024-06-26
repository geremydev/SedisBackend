﻿using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History.Medical_Condition.Risk_Factor_Condition;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Risk_Factor;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Infrastructure.Persistence.Repositories.Medical_History.Medical_Conditions.Risk_Factor_Condition
{
    public class PatientRiskFactorRepository : GenericRepository<PatientRiskFactor>, IPatientRiskFactorRepository
    {
        public PatientRiskFactorRepository(SedisContext context) : base(context)
        {
        }
    }
}
