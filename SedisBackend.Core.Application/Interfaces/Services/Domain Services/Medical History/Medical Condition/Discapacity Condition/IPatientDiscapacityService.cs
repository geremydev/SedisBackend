using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Application.Interfaces.Services.Base;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Discapacity_Condition;

namespace SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Medical_Condition.Discapacity_Condition
{
    public interface IPatientDiscapacityService : IGenericService<SavePatientDiscapacityDto, BasePatientDiscapacityDto, PatientDiscapacity>
    {
    }
}
