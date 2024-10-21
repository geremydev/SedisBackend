using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.ClinicalHistoryCommandHandlers;

public sealed record UpdateClinicalHistoryCommand(Guid Id, ClinicalHistoryForUpdateDto ClinicalHistory, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdateClinicalHistoryHandler : IRequestHandler<UpdateClinicalHistoryCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateClinicalHistoryHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateClinicalHistoryCommand request, CancellationToken cancellationToken)
    {
        var clinicalHistoryEntity = await _repository.ClinicalHistory.GetEntityAsync(request.Id, request.TrackChanges);
        if (clinicalHistoryEntity is null)
            throw new EntityNotFoundException(request.Id);

        _mapper.Map(request.ClinicalHistory, clinicalHistoryEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
