using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.DTO.Entities.Users.Patients;
using SedisBackend.Core.Domain.Entities.Users;
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
    private readonly UserManager<User> _userManager;
    public PatchPatientHandler(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager)
    {
        _repository = repository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<(PatientForUpdateDto PatientToPatch, Patient PatientEntity)> Handle(
        PatchPatientCommand request, CancellationToken cancellationToken)
    {
        var patientEntity = await _repository.Patient.GetEntityAsync(request.Id, request.TrackChanges);
        var originalIsActive = patientEntity.IsActive;
        if (patientEntity is null)
            throw new EntityNotFoundException(request.Id);

        var patientToPatch = _mapper.Map<PatientForUpdateDto>(patientEntity);

        request.PatchDoc.ApplyTo(patientToPatch, (error) =>
        {
            throw new PatchRequestException($"Error applying patch: {error.ErrorMessage}");
        });

        _mapper.Map(patientToPatch, patientEntity);
        patientEntity.IsActive = originalIsActive;
        if (patientEntity.ApplicationUser != null)
        {
            if (patientToPatch.IsActive != null)
            {
                if (!patientEntity.IsActive == patientToPatch.IsActive)
                {
                    patientEntity.IsActive = patientToPatch.IsActive;

                    var currentUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == patientEntity.Id, cancellationToken);
                    if (patientEntity.IsActive == true)
                        await _userManager.AddToRoleAsync(currentUser, "Patient");
                    else
                        await _userManager.RemoveFromRoleAsync(currentUser, "Patient");
                }
            }
            if(patientEntity.BloodType != null)
            {
                patientEntity.BloodType = patientToPatch.BloodType;
            }
            if(patientEntity.BloodTypeLabResultURl != null)
            {
                patientEntity.BloodTypeLabResultURl = patientToPatch.BloodTypeLabResultURl;
            }
            if(patientEntity.Height != null)
            {
                patientEntity.Height = patientToPatch.Height;
            }
            if(patientEntity.Weight != null)
            {
                patientEntity.Weight = patientToPatch.Weight;
            }
            if(patientEntity.EmergencyContactName != null)
            {
                patientEntity.EmergencyContactName = patientToPatch.EmergencyContactName;
            }
            if(patientEntity.EmergencyContactPhone != null)
            {
                patientEntity.EmergencyContactPhone = patientToPatch.EmergencyContactPhone;
            }
            if (patientEntity.PrimaryCarePhysicianId != null) 
            {
                patientEntity.PrimaryCarePhysicianId = patientToPatch.PrimaryCarePhysicianId;
            }


        }

        await _repository.SaveAsync(cancellationToken);

        return (patientToPatch, patientEntity);
    }
}
