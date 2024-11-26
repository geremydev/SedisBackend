using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.AllergyCommandHandlers;

public record DeleteAllergyCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeletePatientAllergyHandler : IRequestHandler<DeleteAllergyCommand>
{
    private readonly IRepositoryManager _repository;

    public DeletePatientAllergyHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteAllergyCommand request, CancellationToken cancellationToken)
    {
        var allergy = await _repository.Allergy.GetEntityAsync(request.Id, request.TrackChanges);
        if (allergy is null)
            throw new EntityNotFoundException(request.Id);

        _repository.Allergy.DeleteEntity(allergy);
        await _repository.SaveAsync(cancellationToken);
    }
}
