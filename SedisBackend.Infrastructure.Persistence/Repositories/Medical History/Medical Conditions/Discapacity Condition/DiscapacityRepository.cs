using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Discapacity_Condition;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Infrastructure.Persistence.Repositories.Medical_History.Medical_Conditions.Discapacity_Condition
{
    public class DiscapacityRepository : GenericRepository<Discapacity>, IDiscapacityRepository
    {
        public DiscapacityRepository(SedisContext context) : base(context)
        {
        }
    }
}
