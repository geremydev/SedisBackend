using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Allergies;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.PatientIllness;
using SedisBackend.Core.Domain.DTO.Error;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_History.Allergies;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientIllnessHandlers;
public sealed record CreatePatientIllnessCommand(PatientIllnessForCreationDto patientIllness) : IRequest<PatientIllnessDto>;

public class CreatePatientIllnessHandler : IRequestHandler<CreatePatientIllnessCommand, PatientIllnessDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreatePatientIllnessHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PatientIllnessDto> Handle(CreatePatientIllnessCommand request, CancellationToken cancellationToken)
    {
        var IllnessEntity = _mapper.Map<PatientIllness>(request.patientIllness);
        PatientIllness existingIllness = new();
        try
        {
            existingIllness = await _repository.PatientIllness.GetEntityAsync(request.patientIllness.PatientId, request.patientIllness.IllnessId, false);
            if (existingIllness != null && existingIllness.Status == "Activo")
            {
                throw new Exception("This patient has already registered this Illness");
            }
            else if (existingIllness != null && existingIllness.Status == "Inactivo")
            {
                _mapper.Map(request.patientIllness, existingIllness);
                request.patientIllness.Status = "Activo";
                _repository.PatientIllness.UpdateEntity(existingIllness);
                await _repository.SaveAsync(cancellationToken);
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType() == typeof(KeyNotFoundException))
            {
                _repository.PatientIllness.CreateEntity(IllnessEntity);
                await _repository.SaveAsync(cancellationToken);
            }
            else
            {
                throw ex;
            }
        }

        return _mapper.Map<PatientIllnessDto>(IllnessEntity);
    }
}
