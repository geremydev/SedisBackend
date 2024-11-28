using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.HealthCenterServiceHandlers;

public record DeleteHealthCenterServiceCommand(Guid HealthCenterId, Guid ServiceId, bool TrackChanges) : IRequest;

internal sealed class DeleteHealthCenterServiceHandler : IRequestHandler<DeleteHealthCenterServiceCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteHealthCenterServiceHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteHealthCenterServiceCommand request, CancellationToken cancellationToken)
    {
        var healthCenterService = await _repository.HealthCenterServices.GetEntityAsync(request.HealthCenterId, request.ServiceId, request.TrackChanges);
        if (healthCenterService is null)
            throw new EntityNotFoundException(request.ServiceId);
        healthCenterService.Status = false;
        _repository.HealthCenterServices.UpdateEntity(healthCenterService);
        await _repository.SaveAsync(cancellationToken);
    }
}
