using MediatR;
using SedisBackend.Core.Domain.Exceptions.EntitiesExceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.LabTestCommandHandlers;
public record DeleteLabTestCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeleteLabTestHandler : IRequestHandler<DeleteLabTestCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteLabTestHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteLabTestCommand request, CancellationToken cancellationToken)
    {
        var labtest = await _repository.LabTest.GetEntityAsync(request.Id, request.TrackChanges);
        if (labtest is null)
            throw new LabTestNotFoundException(request.Id);

        _repository.LabTest.DeleteEntity(labtest);
        await _repository.SaveAsync(cancellationToken);
    }
}
