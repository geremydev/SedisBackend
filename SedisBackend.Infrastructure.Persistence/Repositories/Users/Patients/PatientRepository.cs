using SedisBackend.Core.Application.Interfaces.Repositories.Users.Patients;
using SedisBackend.Core.Domain.Users.Patients;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Infrastructure.Persistence.Repositories.Users.Patients
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(SedisContext context) : base(context)
        {
        }
    }
}
