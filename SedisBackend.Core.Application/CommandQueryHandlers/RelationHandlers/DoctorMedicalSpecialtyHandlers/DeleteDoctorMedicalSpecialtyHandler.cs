using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.MedicalSpecialtyHandlers;

public record DeleteDoctorMedicalSpecialtyCommand(Guid DoctorId, Guid MedicalSpecialtyId, bool TrackChanges) : IRequest;

internal sealed class DeleteHealthCenterServiceHandler : IRequestHandler<DeleteDoctorMedicalSpecialtyCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteHealthCenterServiceHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteDoctorMedicalSpecialtyCommand request, CancellationToken cancellationToken)
    {
        var doctorMedicalSpecialty = await _repository.DoctorMedicalSpecialty.GetEntityAsync(request.DoctorId, request.MedicalSpecialtyId, request.TrackChanges);
        if (doctorMedicalSpecialty is null)
            throw new EntityNotFoundException(request.MedicalSpecialtyId);
        doctorMedicalSpecialty.Status = false;
        _repository.DoctorMedicalSpecialty.UpdateEntity(doctorMedicalSpecialty);
        await _repository.SaveAsync(cancellationToken);
    }
}
