using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.DTO.Entities.Users.Assistants;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.AssistantHandlers;

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
        var executionStrategy = await _repository.CreateExecutionStrategy();

        return await executionStrategy.ExecuteAsync(async () =>
        {
            await using var transaction = await _repository.BeginTransactionAsync(cancellationToken);

            try
            {
                var existingUser = await _userManager.Users
            .FirstOrDefaultAsync(u => u.Id == request.assistant.UserId, cancellationToken);

                if (existingUser == null)
                {
                    throw new UserNotFoundException(request.assistant.UserId.ToString());
                }
                var assistantEntity = new Assistant
                {
                    Id = request.assistant.UserId,
                    HealthCenterId = request.assistant.HealthCenterId,
                    Status = true
                };

                _repository.Assistant.CreateEntity(assistantEntity);

                await _repository.SaveAsync(cancellationToken);

                await _userManager.AddToRoleAsync(existingUser, "Assistant");


                await transaction.CommitAsync(cancellationToken);

                return _mapper.Map<AssistantDto>(assistantEntity);
                    catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        });
    }
}
