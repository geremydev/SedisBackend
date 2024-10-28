using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Domain.DTO.Entities.Users.Patients;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Enums;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.PatientCommandHandlers;

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

        SexEnum sex;

        if (Enum.TryParse(request.Patient.Sex.ToString(), out sex))
        {
            var patientEntity = await _repository.Patient.GetEntityAsync(request.Id, true);

            patientEntity.ApplicationUser.FirstName = request.Patient.FirstName;
            patientEntity.ApplicationUser.LastName = request.Patient.LastName;
            patientEntity.ApplicationUser.CardId = request.Patient.CardId;
            patientEntity.ApplicationUser.IsActive = request.Patient.IsActive;
            patientEntity.ApplicationUser.Birthdate = request.Patient.Birthdate;
            patientEntity.ApplicationUser.Sex = sex;
            patientEntity.ApplicationUser.Email = request.Patient.Email;
            patientEntity.ApplicationUser.EmailConfirmed = false;
            patientEntity.ApplicationUser.PhoneNumber = request.Patient.PhoneNumber;
            patientEntity.ApplicationUser.PhoneNumberConfirmed = false;
            patientEntity.ApplicationUser.ImageUrl = request.Patient.ImageUrl;

            await _repository.SaveAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }
        else
        {
            throw new ArgumentException("Invalid sex value");
        }

        return Unit.Value;
    }
}
