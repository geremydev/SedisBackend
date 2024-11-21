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
            .FirstOrDefaultAsync(u => u.Id == request.doctor.UserId, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException(request.doctor.UserId.ToString());
        }


        var doctorEntity = new Doctor
        {
            Id = request.doctor.UserId,
            LicenseNumber = request.doctor.LicenseNumber,
            CurrentlyWorkingHealthCenters = new List<DoctorHealthCenter>(),
            Specialties = new List<DoctorMedicalSpecialty>()
        };


        _repository.Doctor.CreateEntity(doctorEntity);
        await _repository.SaveAsync(cancellationToken);
        await _userManager.AddToRoleAsync(existingUser, "Doctor");
        await transaction.CommitAsync(cancellationToken);

        return _mapper.Map<DoctorDto>(doctorEntity);
    }
}
