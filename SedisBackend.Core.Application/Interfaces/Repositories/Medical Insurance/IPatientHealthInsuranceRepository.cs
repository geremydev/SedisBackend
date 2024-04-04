using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Domain.Medical_Insurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Interfaces.Repositories.Medical_Insurance
{
    public interface IPatientHealthInsuranceRepository : IGenericRepository<PatientHealthInsurance>
    {
    }
}
