using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SedisBackend.Core.Domain.DTO.Entities.Users.Patients;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.PatientHandlers;

public sealed record PatchPatientCommand(Guid Id, bool TrackChanges, JsonPatchDocument<PatientForUpdateDto> PatchDoc)
    : IRequest<(PatientForUpdateDto PatientToPatch, Patient PatientEntity)>;

internal sealed class PatchPatientHandler
    : IRequestHandler<PatchPatientCommand, (PatientForUpdateDto PatientToPatch, Patient PatientEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public PatchPatientHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(PatientForUpdateDto PatientToPatch, Patient PatientEntity)> Handle(
        PatchPatientCommand request, CancellationToken cancellationToken)
    {
        var PatientEntity = await _repository.Patient.GetEntityAsync(request.Id, request.TrackChanges);
        if (PatientEntity is null)
            throw new EntityNotFoundException(request.Id);

        var PatientToPatch = _mapper.Map<PatientForUpdateDto>(PatientEntity);
        request.PatchDoc.ApplyTo(PatientToPatch);

        _mapper.Map(PatientToPatch, PatientEntity);
        await _repository.SaveAsync(cancellationToken);

        return (PatientToPatch, PatientEntity);
    }
}
