﻿using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Application.Interfaces.Services.Base;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Illness_Condition;

namespace SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Medical_Condition.Illness_Condition
{
    public interface IPatientIllnessService : IGenericService<SavePatientIllnessDto, BasePatientIllnessDto, PatientIllness>
    {
    }
}
