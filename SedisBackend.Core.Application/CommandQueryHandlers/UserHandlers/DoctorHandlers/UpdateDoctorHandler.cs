using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Domain.DTO.Entities.Users.Doctors;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.DoctorHandlers;

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

        var doctorEntity = await _repository.Doctor.GetEntityAsync(request.Id, true);

        if (doctorEntity.Status != request.Doctor.Status)
        {
            doctorEntity.Status = request.Doctor.Status;
            if (doctorEntity.Status)
                await _userManager.AddToRoleAsync(existingUser, "Doctor");
            else
                await _userManager.RemoveFromRoleAsync(existingUser, "Doctor");
        }
        doctorEntity.ApplicationUser.PhoneNumberConfirmed = false;

        await _repository.SaveAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);

        return Unit.Value;
    }
}
