using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_Insurance;
using SedisBackend.Core.Application.Interfaces.Services.Base;
using SedisBackend.Core.Domain.Medical_Insurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_Insurance
{
    public interface IPatientHealthInsuranceService : IGenericService<SavePatientHealthInsuranceDto, BasePatientHealthInsuranceDto, PatientHealthInsurance>
    {
    }
}
