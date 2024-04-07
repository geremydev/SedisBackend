
using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Products;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Products;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Services.Domain_Services.Products
{
    public class MedicationService : GenericService<SaveMedicationDto, BaseMedicationDto, Medication>, IMedicationService
    {
        public MedicationService(IGenericRepository<Medication> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
