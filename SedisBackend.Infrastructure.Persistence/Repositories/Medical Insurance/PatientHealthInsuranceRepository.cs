using SedisBackend.Core.Application.Interfaces.Repositories.Medical_Insurance;
using SedisBackend.Core.Domain.Medical_Insurance;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Infrastructure.Persistence.Repositories.Medical_Insurance
{
    public class PatientHealthInsuranceRepository : GenericRepository<PatientHealthInsurance>, IPatientHealthInsuranceRepository
    {
        public PatientHealthInsuranceRepository(SedisContext context) : base(context)
        {
        }
    }
}
