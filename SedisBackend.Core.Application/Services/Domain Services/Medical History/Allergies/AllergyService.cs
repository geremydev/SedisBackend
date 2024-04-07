using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Allergies;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Allergies;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Domain.Medical_History.Allergies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Services.Domain_Services.Medical_History.Allergies
{
    public class AllergyService : GenericService<SaveAllergyDto, BaseAllergyDto, Allergy>, IAllergyService
    {
        public AllergyService(IGenericRepository<Allergy> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
