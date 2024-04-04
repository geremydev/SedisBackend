using SedisBackend.Core.Application.Interfaces.Repositories.Prescriptions;
using SedisBackend.Core.Domain.Presctiptions;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Infrastructure.Persistence.Repositories.Presctiption
{
    public class PrescriptionRepository : GenericRepository<Prescription>, IPrescriptionRepository
    {
        public PrescriptionRepository(SedisContext context) : base(context)
        {
        }
    }
}
