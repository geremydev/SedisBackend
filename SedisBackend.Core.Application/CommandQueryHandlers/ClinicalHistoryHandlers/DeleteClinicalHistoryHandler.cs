using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.ClinicalHistoryCommandHandlers;

public record DeleteClinicalHistoryCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeleteClinicalHistoryHandler : IRequestHandler<DeleteClinicalHistoryCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteClinicalHistoryHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteClinicalHistoryCommand request, CancellationToken cancellationToken)
    {
        var clinicalHistory = await _repository.ClinicalHistory.GetEntityAsync(request.Id, request.TrackChanges);
        if (clinicalHistory is null)
            throw new EntityNotFoundException(request.Id);

        clinicalHistory.Status = "Deleted";
        await _repository.SaveAsync(cancellationToken);
    }
}
