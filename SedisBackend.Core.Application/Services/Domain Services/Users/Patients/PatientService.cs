using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Allergies;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Clinical_History;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Family_History;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Risk_Factor_Condition;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Vaccines;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Patients;
using SedisBackend.Core.Application.Interfaces.Loggers;
using SedisBackend.Core.Application.Interfaces.Repositories.Users.Patients;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Patients;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Domain.Users.Patients;

namespace SedisBackend.Core.Application.Services.Domain_Services.Users.Patients
{
    public class PatientService : GenericService<SavePatientDto, BasePatientDto, Patient>, IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        public PatientService(IPatientRepository repository, ILoggerManager logger, IMapper mapper) : base(repository, logger, mapper)
        {
            _patientRepository = repository;
            _mapper = mapper;
        }

        public override async Task<List<BasePatientDto>> GetAllWithIncludeAsync(List<string> properties)
        {
            var query = await base.GetAllWithIncludeAsync(properties);
            foreach (var patient in query)
            {
                patient.Allergies = patient.Allergies.Select(a => _mapper.Map<BasePatientAllergyDto>(a)).ToList();
            }
            foreach (var patient in query)
            {
                patient.ClinicalHistories = patient.ClinicalHistories.Select(a => _mapper.Map<BaseClinicalHistoryDto>(a)).ToList();
            }
            foreach (var patient in query)
            {
                patient.Discapacities = patient.Discapacities.Select(a => _mapper.Map<BasePatientDiscapacityDto>(a)).ToList();
            }
            foreach (var patient in query)
            {
                patient.RiskFactors = patient.RiskFactors.Select(a => _mapper.Map<BasePatientRiskFactorDto>(a)).ToList();
            }
            foreach (var patient in query)
            {
                patient.Vaccines = patient.Vaccines.Select(a => _mapper.Map<BasePatientVaccineDto>(a)).ToList();
            }
            foreach (var patient in query)
            {
                patient.FamilyHistories = patient.FamilyHistories.Select(a => _mapper.Map<BaseFamilyHistoryDto>(a)).ToList();
            }
            return query;
        }

    }
}
