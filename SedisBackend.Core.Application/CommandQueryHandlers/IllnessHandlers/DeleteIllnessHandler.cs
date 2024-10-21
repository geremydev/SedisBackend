using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.IllnessCommandHandlers;

public record DeleteIllnessCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeleteIllnessHandler : IRequestHandler<DeleteIllnessCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteIllnessHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteIllnessCommand request, CancellationToken cancellationToken)
    {
        var illness = await _repository.Illness.GetEntityAsync(request.Id, request.TrackChanges);
        if (illness is null)
            throw new EntityNotFoundException(request.Id);

        _repository.Illness.DeleteEntity(illness);
        await _repository.SaveAsync(cancellationToken);
    }
}
