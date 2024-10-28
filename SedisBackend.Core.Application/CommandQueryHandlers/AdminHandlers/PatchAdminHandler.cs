using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SedisBackend.Core.Domain.DTO.Entities.Users.Admins;
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

    public PatchAdminHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(AdminForUpdateDto AdminToPatch, Admin AdminEntity)> Handle(
        PatchAdminCommand request, CancellationToken cancellationToken)
    {
        // Retrieve the Admin entity from the repository
        var adminEntity = await _repository.Admin.GetEntityAsync(request.Id, request.TrackChanges);

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

        // Update the nested ApplicationUser properties if they are not null
        if (adminEntity.ApplicationUser != null)
        {
            if (adminToPatch.FirstName != null)
                adminEntity.ApplicationUser.FirstName = adminToPatch.FirstName;

            if (adminToPatch.LastName != null)
                adminEntity.ApplicationUser.LastName = adminToPatch.LastName;

            if (adminToPatch.CardId != null)
                adminEntity.ApplicationUser.CardId = adminToPatch.CardId;

            if (adminToPatch.IsActive != null)
                adminEntity.ApplicationUser.IsActive = adminToPatch.IsActive;

            if (adminToPatch.Birthdate != null)
                adminEntity.ApplicationUser.Birthdate = adminToPatch.Birthdate;

            if (adminToPatch.Email != null)
                adminEntity.ApplicationUser.Email = adminToPatch.Email;

            if (adminToPatch.Sex != null)
                adminEntity.ApplicationUser.Sex = Enum.Parse<SexEnum>(adminToPatch.Sex, true);

            if (adminToPatch.PhoneNumber != null)
                adminEntity.ApplicationUser.PhoneNumber = adminToPatch.PhoneNumber;
        }

        // Save changes to the repository
        await _repository.SaveAsync(cancellationToken);

        // Return the patched DTO and the updated entity
        return (adminToPatch, adminEntity);
    }
}
