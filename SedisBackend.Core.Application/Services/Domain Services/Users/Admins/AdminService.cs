using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Admins;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Admins;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Domain.Users.Admins;

namespace SedisBackend.Core.Application.Services.Domain_Services.Users.Admins
{
    public class AdminService : GenericService<SaveAdminDto, BaseAdminDto, Admin>, IAdminService
    {
        public AdminService(IGenericRepository<Admin> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
