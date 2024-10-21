using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.VaccineCommandHandlers;

public record DeleteVaccineCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeleteVaccineHandler : IRequestHandler<DeleteVaccineCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteVaccineHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteVaccineCommand request, CancellationToken cancellationToken)
    {
        var vaccine = await _repository.Vaccine.GetEntityAsync(request.Id, request.TrackChanges);
        if (vaccine is null)
            throw new EntityNotFoundException(request.Id);

        _repository.Vaccine.DeleteEntity(vaccine);
        await _repository.SaveAsync(cancellationToken);
    }
}
