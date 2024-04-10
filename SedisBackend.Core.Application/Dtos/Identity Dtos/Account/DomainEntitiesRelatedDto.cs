using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Admins;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Assistants;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Patients;

namespace SedisBackend.Core.Application.Dtos.Identity_Dtos.Account
{
    public class DomainEntitiesRelatedDto
    {
        public BaseAdminDto? Admin { get; set; } = null;
        public BaseAssistantDto Assistant { get; set; } = null;
        public BasePatientDto Patient { get; set; } = null;
    }
}
