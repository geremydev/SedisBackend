using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.DTO.Entities.Users.Assistants;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Enums;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.AssistantCommandHandlers;

public sealed record CreateAssistantCommand(AssistantForCreationDto assistant) : IRequest<AssistantDto>;

internal sealed class CreateAssistantHandler : IRequestHandler<CreateAssistantCommand, AssistantDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public CreateAssistantHandler(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager)
    {
        _repository = repository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<AssistantDto> Handle(CreateAssistantCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await _repository.BeginTransactionAsync(cancellationToken);

        var existingUser = await _userManager.Users
            .FirstOrDefaultAsync(u => u.CardId == request.assistant.CardId || u.PhoneNumber == request.assistant.PhoneNumber, cancellationToken);

        if (existingUser != null)
        {
            throw new UserExistsException(existingUser.CardId);
        }

        if (!Enum.TryParse<SexEnum>(request.assistant.Sex, true, out var sex))
        {
            throw new ArgumentException("Invalid sex value");
        }

        var userEntity = _mapper.Map<User>(request.assistant);
        userEntity.UserName = null;
        userEntity.Email = request.assistant.Email;
        userEntity.EmailConfirmed = false;
        userEntity.IsActive = true;
        userEntity.Sex = sex;
        userEntity.PhoneNumberConfirmed = false;
        userEntity.ImageUrl = ".";

        var userCreationResult = await _userManager.CreateAsync(userEntity, request.assistant.Password);

        if (!userCreationResult.Succeeded)
        {
            var errorMessages = string.Join(", ", userCreationResult.Errors.Select(e => e.Description));
            throw new TransactionFailedException($"Error inserting an assistant: {errorMessages}");
        }

        await _userManager.AddToRoleAsync(userEntity, RolesEnum.Assistant.ToString());

        var assistantEntity = new Assistant
        {
            Id = userEntity.Id,
            HealthCenterId = request.assistant.HealthCenterId
        };

        var patient = new Patient
        {
            Id = userEntity.Id
        };

        _repository.Patient.CreateEntity(patient);
        _repository.Assistant.CreateEntity(assistantEntity);

        await _repository.SaveAsync(cancellationToken);

        await transaction.CommitAsync(cancellationToken);

        return _mapper.Map<AssistantDto>(assistantEntity);
    }
}
