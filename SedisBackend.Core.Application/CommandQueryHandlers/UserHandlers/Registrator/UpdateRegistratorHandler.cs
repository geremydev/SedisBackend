using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.DTO.Entities.Users.Registrator;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.RegistratorHandlers;

public sealed record UpdateRegistratorCommand(Guid Id, RegistratorForUpdateDto Registrator, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdateRegistratorHandler : IRequestHandler<UpdateRegistratorCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public UpdateRegistratorHandler(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager)
    {
        _repository = repository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<Unit> Handle(UpdateRegistratorCommand request, CancellationToken cancellationToken)
    {
        var executionStrategy = await _repository.CreateExecutionStrategy();

        return await executionStrategy.ExecuteAsync(async () =>
        {
            await using var transaction = await _repository.BeginTransactionAsync(cancellationToken);

            try
            {
                var existingUser = await _userManager.FindByIdAsync(request.Id.ToString());

                if (existingUser is null)
                    throw new EntityNotFoundException(request.Id);

                var RegistratorEntity = await _repository.Registrator.GetEntityAsync(request.Id, true);
                RegistratorEntity.HealthCenterId = request.Registrator.HealthCenterId;
                if (RegistratorEntity.Status != request.Registrator.Status)
                {
                    RegistratorEntity.Status = request.Registrator.Status;
                    if (RegistratorEntity.Status)
                        await _userManager.AddToRoleAsync(existingUser, "Registrator");
                    else
                        await _userManager.RemoveFromRoleAsync(existingUser, "Registrator");
                }

                await _repository.SaveAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);

                return Unit.Value;
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        });
    }
}
