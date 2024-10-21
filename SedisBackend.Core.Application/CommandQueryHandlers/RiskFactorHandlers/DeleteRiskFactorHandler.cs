using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.RiskFactorCommandHandlers;

public record DeleteRiskFactorCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeleteRiskFactorHandler : IRequestHandler<DeleteRiskFactorCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteRiskFactorHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteRiskFactorCommand request, CancellationToken cancellationToken)
    {
        var riskFactor = await _repository.RiskFactor.GetEntityAsync(request.Id, request.TrackChanges);
        if (riskFactor is null)
            throw new EntityNotFoundException(request.Id);

        _repository.RiskFactor.DeleteEntity(riskFactor);
        await _repository.SaveAsync(cancellationToken);
    }
}
