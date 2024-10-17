﻿using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Family_History;
using SedisBackend.Core.Application.Interfaces.Services.Base;
using SedisBackend.Core.Domain.Medical_History.Family_History;

namespace SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Family_History
{
    public interface IFamilyHistoryService : IGenericService<SaveFamilyHistoryDto, BaseFamilyHistoryDto, FamilyHistory>
    {
    }
}
