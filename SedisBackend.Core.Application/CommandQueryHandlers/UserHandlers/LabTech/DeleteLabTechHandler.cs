using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.LabTechHandlers;

public record DeleteLabTechCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeleteRegistratorHandler : IRequestHandler<DeleteLabTechCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteRegistratorHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteLabTechCommand request, CancellationToken cancellationToken)
    {
        var LabTech = await _repository.LabTech.GetEntityAsync(request.Id, request.TrackChanges);
        if (LabTech is null)
            throw new EntityNotFoundException(request.Id);

        LabTech.Status = false;
        //_repository.LabTech.DeleteEntity(LabTech);
        await _repository.SaveAsync(cancellationToken);
    }
}
