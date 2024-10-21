using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.DiscapacityCommandHandlers;

public record DeleteDiscapacityCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeleteDiscapacityHandler : IRequestHandler<DeleteDiscapacityCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteDiscapacityHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteDiscapacityCommand request, CancellationToken cancellationToken)
    {
        var discapacity = await _repository.Discapacity.GetEntityAsync(request.Id, request.TrackChanges);
        if (discapacity is null)
            throw new EntityNotFoundException(request.Id);

        _repository.Discapacity.DeleteEntity(discapacity);
        await _repository.SaveAsync(cancellationToken);
    }
}
