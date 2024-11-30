using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.DTO.Entities.Users.Registrator;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.RegistratorHandlers;

public sealed record PatchRegistratorCommand(Guid Id, bool TrackChanges, JsonPatchDocument<RegistratorForUpdateDto> PatchDoc)
    : IRequest<(RegistratorForUpdateDto RegistratorToPatch, Registrator RegistratorEntity)>;

internal sealed class PatchRegistratorHandler
    : IRequestHandler<PatchRegistratorCommand, (RegistratorForUpdateDto RegistratorToPatch, Registrator RegistratorEntity)>
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

    public async Task<(RegistratorForUpdateDto RegistratorToPatch, Registrator RegistratorEntity)> Handle(
        PatchRegistratorCommand request, CancellationToken cancellationToken)
    {
        // Retrieve the Registrator entity from the repository
        var RegistratorEntity = await _repository.Registrator.GetEntityAsync(request.Id, request.TrackChanges);
        var originalIsActive = RegistratorEntity.Status;

        // Check if the Registrator entity exists
        if (RegistratorEntity is null)
            throw new EntityNotFoundException(request.Id);

        // Map the existing Registrator entity to the RegistratorForUpdateDto
        var RegistratorToPatch = _mapper.Map<RegistratorForUpdateDto>(RegistratorEntity);

        // Apply the patch document to the DTO
        request.PatchDoc.ApplyTo(RegistratorToPatch, (error) =>
        {
            // Handle any errors when applying the patch
            throw new PatchRequestException($"Error applying patch: {error.ErrorMessage}");
        });

        // Map the updated DTO back to the Registrator entity
        _mapper.Map(RegistratorToPatch, RegistratorEntity);
        RegistratorEntity.Status = originalIsActive;        //Esto es porque no encuentro por qué se resetea el isActive so this is wrong but later i'm gonna fix it

        // Update the nested ApplicationUser properties if they are not null
        if (RegistratorEntity.ApplicationUser != null)
        {
            if (RegistratorEntity.Status != RegistratorToPatch.Status)
            {
                RegistratorEntity.Status = RegistratorToPatch.Status;

                var currentUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == RegistratorEntity.Id, cancellationToken);

                if (RegistratorEntity.Status)
                    await _userManager.AddToRoleAsync(currentUser, "Registrator");
                else
                    await _userManager.RemoveFromRoleAsync(currentUser, "Registrator");
            }

            if (RegistratorToPatch.HealthCenterId != null)
            {
                RegistratorEntity.HealthCenterId = RegistratorToPatch.HealthCenterId;
            }
        }

        // Save changes to the repository
        await _repository.SaveAsync(cancellationToken);

        // Return the patched DTO and the updated entity
        return (RegistratorToPatch, RegistratorEntity);
    }
}
