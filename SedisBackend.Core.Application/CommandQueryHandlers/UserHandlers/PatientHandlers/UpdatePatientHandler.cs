using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Domain.DTO.Entities.Users.Patients;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.PatientHandlers;

public sealed record UpdatePatientCommand(Guid Id, PatientForUpdateDto Patient, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdatePatientHandler : IRequestHandler<UpdatePatientCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public UpdatePatientHandler(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager)
    {
        _repository = repository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<Unit> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await _repository.BeginTransactionAsync(cancellationToken);

        var existingUser = await _userManager.FindByIdAsync(request.Id.ToString());

        if (existingUser is null)
            throw new EntityNotFoundException(request.Id);

        var patientEntity = await _repository.Patient.GetEntityAsync(request.Id, true);

        patientEntity.BloodType = request.Patient.BloodType;
        patientEntity.EmergencyContactName = request.Patient.EmergencyContactName;
        patientEntity.EmergencyContactPhone = request.Patient.EmergencyContactPhone;
        patientEntity.Height = request.Patient.Height;
        patientEntity.Weight = request.Patient.Weight;
        patientEntity.PrimaryCarePhysicianId = request.Patient.PrimaryCarePhysicianId;

        if (patientEntity.Status != request.Patient.Status)
        {
            patientEntity.Status = request.Patient.Status;
            if (patientEntity.Status)
                await _userManager.AddToRoleAsync(existingUser, "Patient");
            else
                await _userManager.RemoveFromRoleAsync(existingUser, "Patient");
        }

        await _repository.SaveAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);

        return Unit.Value;
    }
}
