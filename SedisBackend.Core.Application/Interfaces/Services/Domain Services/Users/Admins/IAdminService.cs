using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Admins;
using SedisBackend.Core.Application.Interfaces.Services.Base;
using SedisBackend.Core.Domain.Users.Admins;

namespace SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Admins
{
    public interface IAdminService : IGenericService<SaveAdminDto, BaseAdminDto, Admin>
    {
    }
}
