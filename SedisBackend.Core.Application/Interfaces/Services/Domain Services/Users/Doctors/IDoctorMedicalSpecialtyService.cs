using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Doctors;
using SedisBackend.Core.Application.Interfaces.Services.Base;
using SedisBackend.Core.Domain.Users.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Doctors
{
    public interface IDoctorMedicalSpecialtyService : IGenericService<SaveDoctorMedicalSpecialtyDto, BaseDoctorMedicalSpeciality, DoctorMedicalSpecialty>
    {
    }
}
