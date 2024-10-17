using SedisBackend.Core.Application.Dtos.Domain_Dtos.Products;
using SedisBackend.Core.Application.Interfaces.Services.Base;
using SedisBackend.Core.Domain.Products;

namespace SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Products
{
    public interface IMedicationService : IGenericService<SaveMedicationDto, BaseMedicationDto, Medication>
    {
    }
}
