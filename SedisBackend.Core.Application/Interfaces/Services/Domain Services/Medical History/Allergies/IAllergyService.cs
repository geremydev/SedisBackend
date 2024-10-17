﻿using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Allergies;
using SedisBackend.Core.Application.Interfaces.Services.Base;
using SedisBackend.Core.Domain.Medical_History.Allergies;

namespace SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Allergies
{
    public interface IAllergyService : IGenericService<SaveAllergyDto, BaseAllergyDto, Allergy>
    {
    }
}
