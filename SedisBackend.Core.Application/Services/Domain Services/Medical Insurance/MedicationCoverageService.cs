﻿using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_Insurance;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_Insurance;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Domain.Medical_Insurance;

namespace SedisBackend.Core.Application.Services.Domain_Services.Medical_Insurance
{
    public class MedicationCoverageService : GenericService<SaveMedicationlCoverageDto, BaseMedicationCoverageDto, MedicationCoverage>, IMedicationCoverageService
    {
        public MedicationCoverageService(IGenericRepository<MedicationCoverage> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
