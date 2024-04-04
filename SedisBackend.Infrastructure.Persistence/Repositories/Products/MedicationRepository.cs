using SedisBackend.Core.Application.Interfaces.Repositories.Products;
using SedisBackend.Core.Domain.Products;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Infrastructure.Persistence.Repositories.Products
{
    public class MedicationRepository : GenericRepository<Medication>, IMedicationRepository
    {
        public MedicationRepository(SedisContext context) : base(context)
        {
        }
    }
}
