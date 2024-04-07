using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Allergies;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Allergies;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Domain.Medical_History.Allergies;

namespace SedisBackend.Core.Application.Services.Domain_Services.Medical_History.Allergies
{
    public class PatientAllergyService : GenericService<SavePatientAllergyDto, BasePatientAllergyDto, PatientAllergy>, IPatientAllergyService
    {
        public PatientAllergyService(IGenericRepository<PatientAllergy> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
