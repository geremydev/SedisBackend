using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Domain.DTO.Entities.Users.Doctors;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.DoctorCommandHandlers;

public sealed record CreateDoctorCommand(DoctorForCreationDto doctor) : IRequest<DoctorDto>;

internal sealed class CreateDoctorHandler : IRequestHandler<CreateDoctorCommand, DoctorDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;  // Inyecta el UserManager para gestionar los usuarios

    public CreateDoctorHandler(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager)
    {
        _repository = repository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<DoctorDto> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        // Start a database transaction to ensure atomicity
        using var transaction = await _repository.BeginTransactionAsync(cancellationToken);

        // Map the request DTO (ApplicationUser) to the entity
        var userEntity = _mapper.Map<User>(request.doctor.User);

        userEntity.UserName = Guid.NewGuid().ToString();
        userEntity.Email = $"{Guid.NewGuid()}@default.com";

        // Create the user in the Identity system
        var userCreationResult = await _userManager.CreateAsync(userEntity, request.doctor.User.Password);

        // Check if user creation succeeded, if not, return failure
        if (!userCreationResult.Succeeded)
        {
            var errorMessages = string.Join(", ", userCreationResult.Errors.Select(e => e.Description));
            throw new TransactionFailedException($"Error inserting a doctor: {errorMessages}");
        }

        // Assign the "Doctor" role to the newly created user
        await _userManager.AddToRoleAsync(userEntity, "Doctor");

        // Create the Doctor entity and link it with the ApplicationUser
        var doctorEntity = new Doctor
        {
            Id = userEntity.Id,  // Use the same ID as ApplicationUser
            LicenseNumber = request.doctor.LicenseNumber,
            CurrentlyWorkingHealthCenters = new List<DoctorHealthCenter>(),
            Specialties = new List<DoctorMedicalSpecialty>()
            // Map any other specific fields required from the request
        };

        // Add Doctor entity to the context
        _repository.Doctor.CreateEntity(doctorEntity);

        // Save changes in the context
        await _repository.SaveAsync(cancellationToken);

        // Commit the transaction after everything succeeds
        await transaction.CommitAsync(cancellationToken);

        // Return the created doctor mapped to DoctorDto
        return _mapper.Map<DoctorDto>(doctorEntity);
    }
}
