using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Domain.DTO.Entities.Users.Doctors;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Enums;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.DoctorCommandHandlers;

public sealed record UpdateDoctorCommand(Guid Id, DoctorForUpdateDto Doctor, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdateDoctorHandler : IRequestHandler<UpdateDoctorCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public UpdateDoctorHandler(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager)
    {
        _repository = repository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<Unit> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await _repository.BeginTransactionAsync(cancellationToken);

        var existingUser = await _userManager.FindByIdAsync(request.Id.ToString());

        if (existingUser is null)
            throw new EntityNotFoundException(request.Id);

        SexEnum sex;

        if (Enum.TryParse(request.Doctor.Sex.ToString(), out sex))
        {
            var doctorEntity = await _repository.Doctor.GetEntityAsync(request.Id, true);

            doctorEntity.ApplicationUser.FirstName = request.Doctor.FirstName;
            doctorEntity.ApplicationUser.LastName = request.Doctor.LastName;
            doctorEntity.ApplicationUser.CardId = request.Doctor.CardId;
            doctorEntity.ApplicationUser.IsActive = request.Doctor.IsActive;
            doctorEntity.ApplicationUser.Birthdate = request.Doctor.Birthdate;
            doctorEntity.ApplicationUser.Sex = sex;
            doctorEntity.ApplicationUser.Email = request.Doctor.Email;
            doctorEntity.ApplicationUser.EmailConfirmed = false;
            doctorEntity.ApplicationUser.PhoneNumber = request.Doctor.PhoneNumber;
            doctorEntity.ApplicationUser.PhoneNumberConfirmed = false;
            doctorEntity.ApplicationUser.ImageUrl = request.Doctor.ImageUrl;

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
