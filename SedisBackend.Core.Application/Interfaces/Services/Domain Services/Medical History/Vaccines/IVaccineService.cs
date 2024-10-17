using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Vaccines;
using SedisBackend.Core.Application.Interfaces.Services.Base;
using SedisBackend.Core.Domain.Medical_History.Vaccines;

namespace SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Vaccines
{
    public interface IVaccineService : IGenericService<SaveVaccineDto, BaseVaccineDto, Vaccine>
    {
    }
}
