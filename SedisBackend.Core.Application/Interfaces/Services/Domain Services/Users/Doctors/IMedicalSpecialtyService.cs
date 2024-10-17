using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Doctors;
using SedisBackend.Core.Application.Interfaces.Services.Base;
using SedisBackend.Core.Domain.Users.Doctors;

namespace SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Doctors
{
    public interface IMedicalSpecialtyService : IGenericService<SaveMedicalSpecialityDto, BaseMedicalSpecialtyDto, MedicalSpecialty>
    {
    }
}
