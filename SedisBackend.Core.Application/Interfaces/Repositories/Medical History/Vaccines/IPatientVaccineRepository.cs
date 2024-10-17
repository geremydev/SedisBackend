using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Domain.Medical_History.Vaccines;

namespace SedisBackend.Core.Application.Interfaces.Repositories.Medical_History
{
    public interface IPatientVaccineRepository : IGenericRepository<PatientVaccine>
    {
    }
}
