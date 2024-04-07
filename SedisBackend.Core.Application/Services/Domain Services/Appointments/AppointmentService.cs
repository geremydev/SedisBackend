using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Appointments;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Appointments;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Domain.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Services.Domain_Services.Appointments
{
    public class AppointmentService : GenericService<SaveAppointmentDto, BaseAppointmentDto, Appointment>, IAppointmentService
    {
        public AppointmentService(IGenericRepository<Appointment> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
