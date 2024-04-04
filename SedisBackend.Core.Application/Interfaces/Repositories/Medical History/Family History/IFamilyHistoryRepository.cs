using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Domain.Medical_History.Family_History;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Interfaces.Repositories.Medical_History
{
    public interface IFamilyHistoryRepository : IGenericRepository<FamilyHistory>
    {
    }
}
