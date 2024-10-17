﻿using SedisBackend.Core.Application.Dtos.ICD11;
using SedisBackend.Core.Application.Interfaces.Repositories.ICD11;
using SedisBackend.Core.Application.Interfaces.Services.ICD11;

namespace SedisBackend.Core.Application.Services.ICD
{
    public class ICD11Service : IICD11Service
    {
        private readonly IICD11Repository _icd11Repository;

        public ICD11Service(IICD11Repository icd11Repository)
        {
            _icd11Repository = icd11Repository;
        }

        public async Task<ICDDestinationEntity> SearchByIdAsync(string query, IDictionary<string, string> headers)
        {
            return await _icd11Repository.SearchByIdAsync(query, headers);
        }
    }
}
