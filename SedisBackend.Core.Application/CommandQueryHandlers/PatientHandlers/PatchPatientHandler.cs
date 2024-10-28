using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SedisBackend.Core.Domain.DTO.Entities.Users.Patients;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Enums;
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
        var patientEntity = await _repository.Patient.GetEntityAsync(request.Id, request.TrackChanges);

        if (patientEntity is null)
            throw new EntityNotFoundException(request.Id);

        var patientToPatch = _mapper.Map<PatientForUpdateDto>(patientEntity);

        request.PatchDoc.ApplyTo(patientToPatch, (error) =>
        {
            throw new PatchRequestException($"Error applying patch: {error.ErrorMessage}");
        });

        _mapper.Map(patientToPatch, patientEntity);

        if (patientEntity.ApplicationUser != null)
        {
            if (patientToPatch.FirstName != null)
                patientEntity.ApplicationUser.FirstName = patientToPatch.FirstName;

            if (patientToPatch.LastName != null)
                patientEntity.ApplicationUser.LastName = patientToPatch.LastName;

            if (patientToPatch.CardId != null)
                patientEntity.ApplicationUser.CardId = patientToPatch.CardId;

            if (patientToPatch.IsActive != null)
                patientEntity.ApplicationUser.IsActive = patientToPatch.IsActive;

            if (patientToPatch.Birthdate != null)
                patientEntity.ApplicationUser.Birthdate = patientToPatch.Birthdate;

            if (patientToPatch.Email != null)
                patientEntity.ApplicationUser.Email = patientToPatch.Email;

            if (patientToPatch.Sex != null)
                patientEntity.ApplicationUser.Sex = Enum.Parse<SexEnum>(patientToPatch.Sex, true);

            if (patientToPatch.PhoneNumber != null)
                patientEntity.ApplicationUser.PhoneNumber = patientToPatch.PhoneNumber;
        }

        await _repository.SaveAsync(cancellationToken);

        return (patientToPatch, patientEntity);
    }
}
