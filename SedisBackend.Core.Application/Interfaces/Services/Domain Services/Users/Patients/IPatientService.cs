using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Patients;
using SedisBackend.Core.Application.Interfaces.Services.Base;
using SedisBackend.Core.Domain.Users.Patients;

namespace SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Patients
{
    public interface IPatientService : IGenericService<SavePatientDto, BasePatientDto, Patient>
    {
    }
}
