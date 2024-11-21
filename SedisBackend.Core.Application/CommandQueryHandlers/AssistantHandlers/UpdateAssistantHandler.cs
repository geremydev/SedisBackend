using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Domain.DTO.Entities.Users.Assistants;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Enums;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.AssistantCommandHandlers;

public sealed record UpdateAssistantCommand(Guid Id, AssistantForUpdateDto Assistant, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdateAssistantHandler : IRequestHandler<UpdateAssistantCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public UpdateAssistantHandler(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager)
    {
        _repository = repository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<Unit> Handle(UpdateAssistantCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await _repository.BeginTransactionAsync(cancellationToken);

        var existingUser = await _userManager.FindByIdAsync(request.Id.ToString());

        if (existingUser is null)
            throw new EntityNotFoundException(request.Id);

        var asisstantEntity = await _repository.Assistant.GetEntityAsync(request.Id, true);
        asisstantEntity.HealthCenterId = request.Assistant.HealthCenterId;
        if(asisstantEntity.IsActive != request.Assistant.IsActive)
        {
            asisstantEntity.IsActive = request.Assistant.IsActive;
            if (asisstantEntity.IsActive)
                await _userManager.AddToRoleAsync(existingUser, "Assistant");
            else
                await _userManager.RemoveFromRoleAsync(existingUser, "Assistant");
        }

        return Unit.Value;
    }
}
