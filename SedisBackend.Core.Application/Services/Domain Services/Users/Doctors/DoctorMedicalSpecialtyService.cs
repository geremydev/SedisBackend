using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Doctors;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Doctors;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Domain.Users.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Services.Domain_Services.Users.Doctors
{
    public class DoctorMedicalSpecialtyService : GenericService<SaveDoctorMedicalSpecialtyDto, BaseDoctorMedicalSpeciality, DoctorMedicalSpecialty>, IDoctorMedicalSpecialtyService
    {
        public DoctorMedicalSpecialtyService(IGenericRepository<DoctorMedicalSpecialty> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
