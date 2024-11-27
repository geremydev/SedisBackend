using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.AdminCommandHandlers;

public record DeleteAdminCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeleteAdminHandler : IRequestHandler<DeleteAdminCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteAdminHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
    {
        var admin = await _repository.Admin.GetEntityAsync(request.Id, request.TrackChanges);
        if (admin is null)
            throw new EntityNotFoundException(request.Id);

        admin.Status = false;
        //_repository.Admin.DeleteEntity(admin);
        await _repository.SaveAsync(cancellationToken);
    }
}
