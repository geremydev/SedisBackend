using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users;

namespace SedisBackend.Core.Application.Dtos.Identity_Dtos.Account
{
    public class DomainEntitiesRelatedDto
    {
        public BaseUserDto? Admin { get; set; } = null;
        public BaseUserDto Assistant { get; set; } = null;
        public BaseUserDto Patient { get; set; } = null;
        public BaseUserDto Doctor { get; set; } = null;
    }
}
