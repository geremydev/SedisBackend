using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.LabTestHandlers;
public record DeleteLabTestCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeleteLabTestHandler : IRequestHandler<DeleteLabTestCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteLabTestHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteLabTestCommand request, CancellationToken cancellationToken)
    {
        var labtest = await _repository.LabTest.GetEntityAsync(request.Id, request.TrackChanges);
        if (labtest is null)
            throw new EntityNotFoundException(request.Id);
        labtest.Status = false;
        _repository.LabTest.UpdateEntity(labtest);
        await _repository.SaveAsync(cancellationToken);
    }
}
