using AutoMapper;
using MediatR;
using SedisBackend.Core.Application.CommandHandlers.AllergyCommandHandlers;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Allergies;
using SedisBackend.Core.Domain.DTO.Error;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_History.Allergies;

namespace SedisBackend.Core.Application.CommandQueryHandlers.PatientAllergyHandlers;
public sealed record CreatePatientAllergyCommand(PatientAllergyForCreationDto patientAllergy) : IRequest<PatientAllergyDto>;

public class CreatePatientAllergyHandler : IRequestHandler<CreatePatientAllergyCommand, PatientAllergyDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreatePatientAllergyHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PatientAllergyDto> Handle(CreatePatientAllergyCommand request, CancellationToken cancellationToken)
    {
        var allergyEntity = _mapper.Map<PatientAllergy>(request.patientAllergy);
        PatientAllergy existingAllergy = new();
        try
        {
            existingAllergy = await _repository.PatientAllergy.GetEntityAsync(request.patientAllergy.PatientId, request.patientAllergy.AllergyId, false);
            if (existingAllergy != null && existingAllergy.Status == true)
            {
                throw new Exception("This patient has already registered this allergy");
            }
            else if(existingAllergy != null && existingAllergy.Status == false)
            {
                _mapper.Map(request.patientAllergy, existingAllergy);
                request.patientAllergy.Status = true;
                await _repository.SaveAsync(cancellationToken);
            }
        }
        catch (Exception ex) 
        {
            if (ex.GetType() == typeof(KeyNotFoundException)) 
            {
                _repository.PatientAllergy.CreateEntity(allergyEntity);
                await _repository.SaveAsync(cancellationToken);
            }
            else
            {
                throw ex; 
            }
        }

        return _mapper.Map<PatientAllergyDto>(allergyEntity);
    }
}
