using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.FamilyHistoryCommandHandlers;

public record DeleteFamilyHistoryCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeleteFamilyHistoryHandler : IRequestHandler<DeleteFamilyHistoryCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteFamilyHistoryHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteFamilyHistoryCommand request, CancellationToken cancellationToken)
    {
        var familyHistory = await _repository.FamilyHistory.GetEntityAsync(request.Id, request.TrackChanges);
        if (familyHistory is null)
            throw new EntityNotFoundException(request.Id);

        familyHistory.Status = true;
        await _repository.SaveAsync(cancellationToken);
    }
}
