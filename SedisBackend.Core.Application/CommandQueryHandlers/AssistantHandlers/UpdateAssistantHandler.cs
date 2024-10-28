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

        SexEnum sex;

        if (Enum.TryParse(request.Assistant.Sex.ToString(), out sex))
        {
            var assistantEntity = await _repository.Assistant.GetEntityAsync(request.Id, true);

            assistantEntity.ApplicationUser.FirstName = request.Assistant.FirstName;
            assistantEntity.ApplicationUser.LastName = request.Assistant.LastName;
            assistantEntity.ApplicationUser.CardId = request.Assistant.CardId;
            assistantEntity.ApplicationUser.IsActive = request.Assistant.IsActive;
            assistantEntity.ApplicationUser.Birthdate = request.Assistant.Birthdate;
            assistantEntity.ApplicationUser.Sex = sex;
            assistantEntity.ApplicationUser.Email = request.Assistant.Email;
            assistantEntity.ApplicationUser.EmailConfirmed = false;
            assistantEntity.ApplicationUser.PhoneNumber = request.Assistant.PhoneNumber;
            assistantEntity.ApplicationUser.PhoneNumberConfirmed = false;
            assistantEntity.ApplicationUser.ImageUrl = request.Assistant.ImageUrl;

            assistantEntity.HealthCenterId = request.Assistant.HealthCenterId;

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
