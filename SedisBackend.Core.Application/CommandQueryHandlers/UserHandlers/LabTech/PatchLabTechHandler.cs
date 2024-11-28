using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.DTO.Entities.Users.LabTech;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.LabTechHandlers;

public sealed record PatchLabTechCommand(Guid Id, bool TrackChanges, JsonPatchDocument<LabTechForUpdateDto> PatchDoc)
    : IRequest<(LabTechForUpdateDto LabTechToPatch, LabTech LabTechEntity)>;

internal sealed class PatchRegistratorHandler
    : IRequestHandler<PatchLabTechCommand, (LabTechForUpdateDto LabTechToPatch, LabTech LabTechEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public PatchRegistratorHandler(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager)
    {
        _repository = repository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<(LabTechForUpdateDto LabTechToPatch, LabTech LabTechEntity)> Handle(
        PatchLabTechCommand request, CancellationToken cancellationToken)
    {
        // Retrieve the LabTech entity from the repository
        var LabTechEntity = await _repository.LabTech.GetEntityAsync(request.Id, request.TrackChanges);
        var originalIsActive = LabTechEntity.Status;

        // Check if the LabTech entity exists
        if (LabTechEntity is null)
            throw new EntityNotFoundException(request.Id);

        // Map the existing LabTech entity to the LabTechForUpdateDto
        var LabTechToPatch = _mapper.Map<LabTechForUpdateDto>(LabTechEntity);

        // Apply the patch document to the DTO
        request.PatchDoc.ApplyTo(LabTechToPatch, (error) =>
        {
            // Handle any errors when applying the patch
            throw new PatchRequestException($"Error applying patch: {error.ErrorMessage}");
        });

        // Map the updated DTO back to the LabTech entity
        _mapper.Map(LabTechToPatch, LabTechEntity);
        LabTechEntity.Status = originalIsActive;        //Esto es porque no encuentro por qué se resetea el isActive so this is wrong but later i'm gonna fix it

        // Update the nested ApplicationUser properties if they are not null
        if (LabTechEntity.ApplicationUser != null)
        {
            if (LabTechEntity.Status != LabTechToPatch.Status)
            {
                LabTechEntity.Status = LabTechToPatch.Status;

                var currentUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == LabTechEntity.Id, cancellationToken);

                if (LabTechEntity.Status)
                    await _userManager.AddToRoleAsync(currentUser, "LabTech");
                else
                    await _userManager.RemoveFromRoleAsync(currentUser, "LabTech");
            }

            if (LabTechToPatch.HealthCenterId != null)
            {
                LabTechEntity.HealthCenterId = LabTechToPatch.HealthCenterId;
            }
        }

        // Save changes to the repository
        await _repository.SaveAsync(cancellationToken);

        // Return the patched DTO and the updated entity
        return (LabTechToPatch, LabTechEntity);
    }
}
