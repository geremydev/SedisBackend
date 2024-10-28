using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.DTO.Entities.Users.Patients;
using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Enums;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Medical_History.Family_History;

namespace SedisBackend.Core.Application.CommandHandlers.PatientCommandHandlers;

public sealed record CreatePatientCommand(PatientForCreationDto patient) : IRequest<PatientDto>;

internal sealed class CreatePatientHandler : IRequestHandler<CreatePatientCommand, PatientDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public CreatePatientHandler(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager)
    {
        _repository = repository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<PatientDto> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await _repository.BeginTransactionAsync(cancellationToken);

        var existingUser = await _userManager.Users.FirstOrDefaultAsync(u => u.CardId == request.patient.CardId || u.PhoneNumber == request.patient.PhoneNumber);

        if (existingUser != null)
        {
            throw new UserExistsException(existingUser.CardId);
        }

        SexEnum sex;

        if (Enum.TryParse<SexEnum>(request.patient.Sex.ToString(), out sex))
        {
            var userEntity = new User
            {
                FirstName = request.patient.FirstName,
                LastName = request.patient.LastName,
                CardId = request.patient.CardId,
                IsActive = true,
                Birthdate = request.patient.Birthdate,
                Sex = sex,
                UserName = null,
                Email = request.patient.Email,
                PhoneNumber = request.patient.PhoneNumber,
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                ImageUrl = request.patient.ImageUrl
            };

            var userCreationResult = await _userManager.CreateAsync(userEntity, request.patient.Password);

            if (!userCreationResult.Succeeded)
            {
                var errorMessages = string.Join(", ", userCreationResult.Errors.Select(e => e.Description));
                throw new TransactionFailedException($"Error inserting an patient: {errorMessages}");
            }

            await _userManager.AddToRoleAsync(userEntity, RolesEnum.Patient.ToString());

            var patientEntity = new Patient
            {
                Id = userEntity.Id,
                ClinicalHistories = new List<ClinicalHistory>(),
                Appointments = new List<Appointment>(),
                Allergies = new List<PatientAllergy>(),
                Illnesses = new List<PatientIllness>(),
                Discapacities = new List<PatientDiscapacity>(),
                RiskFactors = new List<PatientRiskFactor>(),
                Vaccines = new List<PatientVaccine>(),
                FamilyHistories = new List<FamilyHistory>(),
            };

            _repository.Patient.CreateEntity(patientEntity);

            await _repository.SaveAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            return _mapper.Map<PatientDto>(patientEntity);
        }
        else
        {
            throw new ArgumentException("Invalid sex value");
        }
    }
}
