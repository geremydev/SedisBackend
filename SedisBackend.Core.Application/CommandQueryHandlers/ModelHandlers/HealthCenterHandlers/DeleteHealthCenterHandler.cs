using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.HealthCenterHandlers;

public record DeleteHealthCenterCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeleteHealthCenterHandler : IRequestHandler<DeleteHealthCenterCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteHealthCenterHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteHealthCenterCommand request, CancellationToken cancellationToken)
    {
        var healthCenter = await _repository.HealthCenter.GetEntityAsync(request.Id, request.TrackChanges);
        if (healthCenter is null)
            throw new EntityNotFoundException(request.Id);
        healthCenter.Status = false;
        await _repository.SaveAsync(cancellationToken);
    }
}
