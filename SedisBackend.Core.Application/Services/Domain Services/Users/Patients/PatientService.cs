﻿using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Patients;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Application.Interfaces.Repositories.Users.Patients;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Patients;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Domain.Users.Patients;

namespace SedisBackend.Core.Application.Services.Domain_Services.Users.Patients
{
    public class PatientService : GenericService<SavePatientDto, BasePatientDto, Patient>, IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _patientRepository = repository;
        }

    }
}
