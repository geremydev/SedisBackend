using SedisBackend.Core.Application.Dtos.Domain_Dtos.Prescriptions;
using SedisBackend.Core.Application.Interfaces.Services.Base;
using SedisBackend.Core.Domain.Prescriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Presctiprions
{
    public interface IMedicationPrescriptionService : IGenericService<SaveMedicationPrescriptionDto, BaseMedicationPrescriptionDto, MedicationPrescription>
    {
    }
}
