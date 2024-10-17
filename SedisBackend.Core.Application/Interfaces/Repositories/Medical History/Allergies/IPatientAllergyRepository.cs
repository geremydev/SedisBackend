﻿using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Domain.Medical_History.Allergies;

namespace SedisBackend.Core.Application.Interfaces.Repositories.Medical_History.Allergies
{
    public interface IPatientAllergyRepository : IGenericRepository<PatientAllergy>
    {
    }
}
