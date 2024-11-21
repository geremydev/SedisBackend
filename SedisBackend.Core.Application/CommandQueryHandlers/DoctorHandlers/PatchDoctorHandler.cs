using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.DTO.Entities.Users.Doctors;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Enums;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.DoctorHandlers;

public sealed record PatchDoctorCommand(Guid Id, bool TrackChanges, JsonPatchDocument<DoctorForUpdateDto> PatchDoc)
    : IRequest<(DoctorForUpdateDto DoctorToPatch, Doctor DoctorEntity)>;

internal sealed class PatchDoctorHandler
    : IRequestHandler<PatchDoctorCommand, (DoctorForUpdateDto DoctorToPatch, Doctor DoctorEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    public PatchDoctorHandler(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager)
    {
        _repository = repository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<(DoctorForUpdateDto DoctorToPatch, Doctor DoctorEntity)> Handle(
        PatchDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctorEntity = await _repository.Doctor.GetEntityAsync(request.Id, request.TrackChanges);
        var originalIsActive = doctorEntity.IsActive;
        if (doctorEntity is null)
            throw new EntityNotFoundException(request.Id);

        var doctorToPatch = _mapper.Map<DoctorForUpdateDto>(doctorEntity);

        request.PatchDoc.ApplyTo(doctorToPatch, (error) =>
        {
            throw new PatchRequestException($"Error applying patch: {error.ErrorMessage}");
        });

        _mapper.Map(doctorToPatch, doctorEntity);
        doctorEntity.IsActive = originalIsActive;
        if (doctorEntity.ApplicationUser != null)
        {
            if (doctorToPatch.IsActive != null)
            {
                if (doctorEntity.IsActive != doctorToPatch.IsActive)
                {
                    doctorEntity.IsActive = doctorToPatch.IsActive;

                    var currentUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == doctorEntity.Id, cancellationToken);
                    if(doctorEntity.IsActive)
                        await _userManager.AddToRoleAsync(currentUser, "Doctor");
                    else
                        await _userManager.RemoveFromRoleAsync(currentUser, "Doctor");
                }
            }
        }

        await _repository.SaveAsync(cancellationToken);

        return (doctorToPatch, doctorEntity);
    }
}
