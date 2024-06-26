﻿using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Vaccines;
using SedisBackend.Core.Application.Interfaces.Services.Base;
using SedisBackend.Core.Domain.Medical_History.Vaccines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Vaccines
{
    public interface IPatientVaccineService : IGenericService<SavePatientVaccineDto, BasePatientVaccineDto, PatientVaccine>
    {
    }
}
