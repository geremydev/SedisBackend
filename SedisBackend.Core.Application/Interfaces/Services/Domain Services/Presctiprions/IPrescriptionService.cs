using SedisBackend.Core.Application.Dtos.Domain_Dtos.Prescriptions;
using SedisBackend.Core.Application.Interfaces.Services.Base;
using SedisBackend.Core.Domain.Prescriptions;

namespace SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Presctiprions
{
    public interface IPrescriptionService : IGenericService<SavePrescriptionDto, BasePrescriptionDto, Prescription>
    {
    }
}
