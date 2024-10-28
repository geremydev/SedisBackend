using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.DTO.Entities.Users.Doctors;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Enums;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.DoctorCommandHandlers;

public sealed record CreateDoctorCommand(DoctorForCreationDto doctor) : IRequest<DoctorDto>;

internal sealed class CreateDoctorHandler : IRequestHandler<CreateDoctorCommand, DoctorDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public CreateDoctorHandler(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager)
    {
        _repository = repository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<DoctorDto> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await _repository.BeginTransactionAsync(cancellationToken);

        var existingUser = await _userManager.Users
            .FirstOrDefaultAsync(u => u.CardId == request.doctor.CardId || u.PhoneNumber == request.doctor.PhoneNumber, cancellationToken);

        if (existingUser != null)
        {
            throw new UserExistsException(existingUser.CardId);
        }

        if (!Enum.TryParse<SexEnum>(request.doctor.Sex, true, out var sex))
        {
            throw new ArgumentException("Invalid sex value");
        }

        var userEntity = _mapper.Map<User>(request.doctor);
        userEntity.UserName = Guid.NewGuid().ToString();
        userEntity.Email = request.doctor.Email;
        userEntity.IsActive = true;
        userEntity.Sex = sex;
        userEntity.PhoneNumberConfirmed = false;
        userEntity.ImageUrl = ".";

        var userCreationResult = await _userManager.CreateAsync(userEntity, request.doctor.Password);

        if (!userCreationResult.Succeeded)
        {
            var errorMessages = string.Join(", ", userCreationResult.Errors.Select(e => e.Description));
            throw new TransactionFailedException($"Error inserting a doctor: {errorMessages}");
        }

        await _userManager.AddToRoleAsync(userEntity, "Doctor");

        var doctorEntity = new Doctor
        {
            Id = userEntity.Id,
            LicenseNumber = request.doctor.LicenseNumber,
            CurrentlyWorkingHealthCenters = new List<DoctorHealthCenter>(),
            Specialties = new List<DoctorMedicalSpecialty>()
        };

        var patient = new Patient
        {
            Id = userEntity.Id
        };

        _repository.Patient.CreateEntity(patient);
        _repository.Doctor.CreateEntity(doctorEntity);
        await _repository.SaveAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);

        return _mapper.Map<DoctorDto>(doctorEntity);
    }
}
