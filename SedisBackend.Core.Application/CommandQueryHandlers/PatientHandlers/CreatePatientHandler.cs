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

        var existingUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == request.patient.UserId);

        if (existingUser == null)
        {
            throw new UserNotFoundException(request.patient.UserId.ToString());
        }

        var patientEntity = new Patient
        {
            Id = request.patient.UserId,
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

        await _userManager.AddToRoleAsync(existingUser, "Patient");

        await transaction.CommitAsync(cancellationToken);

        return _mapper.Map<PatientDto>(patientEntity);
        
    }
}
