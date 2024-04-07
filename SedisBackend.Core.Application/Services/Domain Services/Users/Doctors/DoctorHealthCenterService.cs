using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Doctors;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Doctors;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Domain.Users.Doctors;

namespace SedisBackend.Core.Application.Services.Domain_Services.Users.Doctors
{
    public class DoctorHealthCenterService : GenericService<SaveDoctorHealthCenterDto, BaseDoctorHealthCenterDto, DoctorHealthCenter>, IDoctorHealthCenterService
    {
        public DoctorHealthCenterService(IGenericRepository<DoctorHealthCenter> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
