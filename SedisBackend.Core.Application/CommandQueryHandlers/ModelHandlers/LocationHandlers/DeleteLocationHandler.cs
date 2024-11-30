using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.LocationHandlers;

public record DeleteLocationCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeleteLocationHandler : IRequestHandler<DeleteLocationCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteLocationHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {
        var location = await _repository.Location.GetEntityAsync(request.Id, request.TrackChanges);
        if (location is null)
            throw new EntityNotFoundException(request.Id);
        location.Status = false;
        _repository.Location.UpdateEntity(location);
        await _repository.SaveAsync(cancellationToken);
    }
}
