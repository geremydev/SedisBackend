using AutoMapper;
using MediatR;
using SedisBackend.Core.Application.CommandHandlers.IllnessCommandHandlers;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions;

namespace SedisBackend.Core.Application.CommandQueryHandlers.IllnessHandlers;
public sealed record CreatePatientIllnessCommand(PatientIllnessForCreationDto patientIllness) : IRequest<PatientIllnessDto>;

internal sealed class CreatePatientIllnessHandler : IRequestHandler<CreatePatientIllnessCommand, PatientIllnessDto>
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
        var patientIllness = _mapper.Map<PatientIllness>(request.patientIllness);
        _repository.PatientIllness.CreateEntity(patientIllness);
        await _repository.SaveAsync(cancellationToken);

        return _mapper.Map<PatientIllnessDto>(patientIllness);
    }
}
