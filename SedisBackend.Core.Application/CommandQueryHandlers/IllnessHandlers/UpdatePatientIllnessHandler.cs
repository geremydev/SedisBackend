using AutoMapper;
using MediatR;
using SedisBackend.Core.Application.CommandHandlers.IllnessCommandHandlers;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.IllnessHandlers;
public sealed record UpdatePatientIllnessCommand(Guid Id, PatientIllnessForUpdateDto patientIllness, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdatePatientIllnessHandler : IRequestHandler<UpdatePatientIllnessCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdatePatientIllnessHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdatePatientIllnessCommand request, CancellationToken cancellationToken)
    {
        var patientIllness = await _repository.PatientIllness.GetEntityAsync(request.Id, request.TrackChanges);
        if (patientIllness is null)
            throw new EntityNotFoundException(request.Id);

        _mapper.Map(request.patientIllness, patientIllness);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }


}
