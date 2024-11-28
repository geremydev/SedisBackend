using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.RegistratorHandlers;

public record DeleteRegistratorCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeleteRegistratorHandler : IRequestHandler<DeleteRegistratorCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteRegistratorHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteRegistratorCommand request, CancellationToken cancellationToken)
    {
        var Registrator = await _repository.Registrator.GetEntityAsync(request.Id, request.TrackChanges);
        if (Registrator is null)
            throw new EntityNotFoundException(request.Id);

        Registrator.Status = false;
        //_repository.Registrator.DeleteEntity(Registrator);
        await _repository.SaveAsync(cancellationToken);
    }
}
