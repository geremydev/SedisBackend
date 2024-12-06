using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.DTO.Entities.Users.Doctors;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.DoctorHandlers;

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
        // TODO mandar el id del healthcenter que pertenece el doctor
        var executionStrategy = await _repository.CreateExecutionStrategy();

        return await executionStrategy.ExecuteAsync(async () =>
        {
            await using var transaction = await _repository.BeginTransactionAsync(cancellationToken);
            try
            {

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
                    Specialties = new List<DoctorMedicalSpecialty>(),
                    Status = true,
                    CurrentlyWorkingHealthCenterId = request.doctor.HealthCenterId
                };


                _repository.Doctor.CreateEntity(doctorEntity);
                await _repository.SaveAsync(cancellationToken);
                await _userManager.AddToRoleAsync(existingUser, "Doctor");
                await transaction.CommitAsync(cancellationToken);

                return _mapper.Map<DoctorDto>(doctorEntity);
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        });
    }
}