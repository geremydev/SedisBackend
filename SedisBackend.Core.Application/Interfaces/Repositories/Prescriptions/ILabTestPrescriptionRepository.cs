using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Domain.Prescriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Interfaces.Repositories.Prescriptions
{
    public interface ILabTestPrescriptionRepository : IGenericRepository<LabTestPrescription>
    {
    }
}
