using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.HealthInsuranceCommandHandlers;

public record DeleteHealthInsuranceCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeleteHealthInsuranceHandler : IRequestHandler<DeleteHealthInsuranceCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteHealthInsuranceHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteHealthInsuranceCommand request, CancellationToken cancellationToken)
    {
        var healthInsurance = await _repository.HealthInsurance.GetEntityAsync(request.Id, request.TrackChanges);
        if (healthInsurance is null)
            throw new EntityNotFoundException(request.Id);

        _repository.HealthInsurance.DeleteEntity(healthInsurance);
        await _repository.SaveAsync(cancellationToken);
    }
}
