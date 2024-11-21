using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.DTO.Entities.Users.Admins;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Enums;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.AdminHandlers;

public sealed record PatchAdminCommand(Guid Id, bool TrackChanges, JsonPatchDocument<AdminForUpdateDto> PatchDoc)
    : IRequest<(AdminForUpdateDto AdminToPatch, Admin AdminEntity)>;

internal sealed class PatchAdminHandler
    : IRequestHandler<PatchAdminCommand, (AdminForUpdateDto AdminToPatch, Admin AdminEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public PatchAdminHandler(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager)
    {
        _repository = repository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<(AdminForUpdateDto AdminToPatch, Admin AdminEntity)> Handle(
        PatchAdminCommand request, CancellationToken cancellationToken)
    {
        // Retrieve the Admin entity from the repository
        var adminEntity = await _repository.Admin.GetEntityAsync(request.Id, request.TrackChanges);
        var originalIsActive = adminEntity.IsActive;

        // Check if the Admin entity exists
        if (adminEntity is null)
            throw new EntityNotFoundException(request.Id);

        // Map the existing Admin entity to the AdminForUpdateDto
        var adminToPatch = _mapper.Map<AdminForUpdateDto>(adminEntity);

        // Apply the patch document to the DTO
        request.PatchDoc.ApplyTo(adminToPatch, (error) =>
        {
            // Handle any errors when applying the patch
            throw new PatchRequestException($"Error applying patch: {error.ErrorMessage}");
        });

        // Map the updated DTO back to the Admin entity
        _mapper.Map(adminToPatch, adminEntity);
        adminEntity.IsActive = originalIsActive;        //Esto es porque no encuentro por qu� se resetea el isActive so this is wrong but later i'm gonna fix it

        // Update the nested ApplicationUser properties if they are not null
        if (adminEntity.ApplicationUser != null)
        {
            

            if (adminToPatch.IsActive != null)
            {
                if (adminEntity.IsActive == true && adminToPatch.IsActive == false)
                {
                    adminEntity.IsActive = adminToPatch.IsActive;

                    var currentUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == adminEntity.Id, cancellationToken);

                    await _userManager.RemoveFromRoleAsync(currentUser, "Admin");
                }
            }
            if(adminToPatch.HealthCenterId != null)
            {
                //adminEntity.ApplicationUser.Health
            }
        }

        // Save changes to the repository
        await _repository.SaveAsync(cancellationToken);

        // Return the patched DTO and the updated entity
        return (adminToPatch, adminEntity);
    }
}