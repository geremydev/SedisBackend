using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.MedicalConsultationHandlers;

public record DeleteMedicalConsultationCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeleteMedicalConsultationHandler : IRequestHandler<DeleteMedicalConsultationCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteMedicalConsultationHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteMedicalConsultationCommand request, CancellationToken cancellationToken)
    {
        var medicalConsultation = await _repository.MedicalConsultation.GetEntityAsync(request.Id, request.TrackChanges);
        if (medicalConsultation is null)
            throw new EntityNotFoundException(request.Id);

        medicalConsultation.Status = "Inactive";
        await _repository.SaveAsync(cancellationToken);
    }
}
