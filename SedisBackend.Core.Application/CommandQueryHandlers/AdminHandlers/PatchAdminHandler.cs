using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SedisBackend.Core.Domain.DTO.Entities.Users.Admins;
using SedisBackend.Core.Domain.Entities.Users.Persons;
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
        var AdminEntity = await _repository.Admin.GetEntityAsync(request.Id, request.TrackChanges);
        if (AdminEntity is null)
            throw new EntityNotFoundException(request.Id);

        var AdminToPatch = _mapper.Map<AdminForUpdateDto>(AdminEntity);
        request.PatchDoc.ApplyTo(AdminToPatch);

        _mapper.Map(AdminToPatch, AdminEntity);
        await _repository.SaveAsync(cancellationToken);

        return (AdminToPatch, AdminEntity);
    }
}
