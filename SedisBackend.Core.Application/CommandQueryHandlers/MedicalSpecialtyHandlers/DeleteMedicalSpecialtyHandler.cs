using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.MedicalSpecialtyCommandHandlers;

public record DeleteMedicalSpecialtyCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeleteMedicalSpecialtyHandler : IRequestHandler<DeleteMedicalSpecialtyCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteMedicalSpecialtyHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteMedicalSpecialtyCommand request, CancellationToken cancellationToken)
    {
        var medicalSpecialty = await _repository.MedicalSpecialty.GetEntityAsync(request.Id, request.TrackChanges);
        if (medicalSpecialty is null)
            throw new EntityNotFoundException(request.Id);

        _repository.MedicalSpecialty.DeleteEntity(medicalSpecialty);
        await _repository.SaveAsync(cancellationToken);
    }
}
