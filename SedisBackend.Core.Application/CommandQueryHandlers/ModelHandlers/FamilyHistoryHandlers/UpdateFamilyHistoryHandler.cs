using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Family_History;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.FamilyHistoryHandlers;

public sealed record UpdateFamilyHistoryCommand(Guid Id, FamilyHistoryForUpdateDto FamilyHistory, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdateFamilyHistoryHandler : IRequestHandler<UpdateFamilyHistoryCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateFamilyHistoryHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateFamilyHistoryCommand request, CancellationToken cancellationToken)
    {
        var familyHistoryEntity = await _repository.FamilyHistory.GetEntityAsync(request.Id, request.TrackChanges);
        if (familyHistoryEntity is null)
            throw new EntityNotFoundException(request.Id);

        _mapper.Map(request.FamilyHistory, familyHistoryEntity);
        _repository.FamilyHistory.UpdateEntity(familyHistoryEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
