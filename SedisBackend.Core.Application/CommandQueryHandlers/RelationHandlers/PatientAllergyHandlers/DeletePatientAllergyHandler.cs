using AutoMapper;
using MediatR;
using SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.MedicationCoverageHandlers;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Allergies;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using System.Threading;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientAllergyHandlers;

public sealed record DeletePatientAllergyCommand(Guid patientId, Guid allergyId, PatientAllergyForUpdateDto PatientAllergy, bool TrackChanges) : IRequest<Unit>;

public class DeletePatientAllergyHandler
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public DeletePatientAllergyHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

        public async Task Handle(DeletePatientAllergyCommand request, CancellationToken cancellationToken)
    {
        var patientAllergy = await _repository.PatientAllergy.GetEntityAsync(request.patientId, request.allergyId, request.TrackChanges);
        if (patientAllergy is null)
            throw new EntityNotFoundException(request.allergyId);
        patientAllergy.Status = false;
        _repository.PatientAllergy.UpdateEntity(patientAllergy);
        await _repository.SaveAsync(cancellationToken);
    }
}
