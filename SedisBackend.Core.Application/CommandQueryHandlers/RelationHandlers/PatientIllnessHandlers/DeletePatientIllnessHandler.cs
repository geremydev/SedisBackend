using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientIllnessHandlers;

public sealed record DeletePatientIllnessCommand(Guid patientId, Guid IllnessId, bool TrackChanges) : IRequest<Unit>;

public class DeletePatientLabTestPrescriptionHandler
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public DeletePatientLabTestPrescriptionHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(DeletePatientIllnessCommand request, CancellationToken cancellationToken)
    {
        var patientIllness = await _repository.PatientIllness.GetEntityAsync(request.patientId, request.IllnessId, request.TrackChanges);
        if (patientIllness is null)
            throw new EntityNotFoundException(request.IllnessId);
        patientIllness.Status = "Inactivo";
        _repository.PatientIllness.UpdateEntity(patientIllness);
        await _repository.SaveAsync(cancellationToken);
    }
}
