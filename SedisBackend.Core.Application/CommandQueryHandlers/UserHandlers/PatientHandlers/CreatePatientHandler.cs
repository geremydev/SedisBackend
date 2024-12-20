using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.DTO.Entities.Users.Patients;
using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_History.Family_History;
using SedisBackend.Core.Domain.Medical_History.MedicalConsultation;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.PatientHandlers;

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
        var executionStrategy = await _repository.CreateExecutionStrategy();

        return await executionStrategy.ExecuteAsync(async () =>
        {
            await using var transaction = await _repository.BeginTransactionAsync(cancellationToken);

            try
            {
                var existingUser = await _userManager.Users
                    .FirstOrDefaultAsync(u => u.Id == request.patient.UserId, cancellationToken);

                if (existingUser == null)
                {
                    throw new UserNotFoundException(request.patient.UserId.ToString());
                }

                var patientEntity = new Patient
                {
                    Id = request.patient.UserId,
                    BloodType = request.patient.BloodType,
                    BloodTypeLabResultURl = request.patient.BloodTypeLabResultURl,
                    Height = request.patient.Height,
                    Weight = request.patient.Weight,
                    EmergencyContactName = request.patient.EmergencyContactName,
                    EmergencyContactPhone = request.patient.EmergencyContactName,
                    PrimaryCarePhysicianId = request.patient.PrimaryCarePhysicianId,
                    MedicalConsultations = new List<MedicalConsultation>(),
                    Appointments = new List<Appointment>(),
                    Allergies = new List<PatientAllergy>(),
                    Illnesses = new List<PatientIllness>(),
                    Discapacities = new List<PatientDiscapacity>(),
                    RiskFactors = new List<PatientRiskFactor>(),
                    Vaccines = new List<PatientVaccine>(),
                    FamilyHistories = new List<FamilyHistory>(),
                    Status = true
                };

                _repository.Patient.CreateEntity(patientEntity);

                await _repository.SaveAsync(cancellationToken);

                await _userManager.AddToRoleAsync(existingUser, "Patient");

                await transaction.CommitAsync(cancellationToken);

                return _mapper.Map<PatientDto>(patientEntity);
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        });
    }
}
