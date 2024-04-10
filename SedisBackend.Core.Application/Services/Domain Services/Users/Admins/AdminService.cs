using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Admins;
using SedisBackend.Core.Application.Interfaces.Repositories.Users.Admins;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.User_Entity_Relation;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Admins;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Assistants;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Patients;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Domain.Users.Admins;

namespace SedisBackend.Core.Application.Services.Domain_Services.Users.Admins
{
    public class AdminService : GenericService<SaveAdminDto, BaseAdminDto, Admin>, IAdminService
    {
        private readonly IAssistantService _assistantService;
        private readonly IPatientService _patientService;
        private readonly IUserEntityRelationService _userEntityRelationService;
        private readonly IMapper _mapper;
        private readonly IAdminRepository _repository;
        public AdminService(
            IAdminRepository repository, 
            IMapper mapper) : base(repository, mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        
    }
}
