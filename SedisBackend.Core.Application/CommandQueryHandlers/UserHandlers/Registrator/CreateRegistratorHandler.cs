using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.DTO.Entities.Users.Registrator;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.RegistratorHandlers;

public sealed record CreateRegistratorCommand(RegistratorForCreationDto Registrator) : IRequest<RegistratorDto>;

internal sealed class CreateRegistratorHandler : IRequestHandler<CreateRegistratorCommand, RegistratorDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public CreateRegistratorHandler(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager)
    {
        _repository = repository;
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<RegistratorDto> Handle(CreateRegistratorCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await _repository.BeginTransactionAsync(cancellationToken);

        // Validar que el usuario exista
        var existingUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == request.Registrator.UserId);

        if (existingUser == null)
        {
            throw new UserNotFoundException(request.Registrator.UserId.ToString());
        }


        var RegistratorEntity = new Registrator
        {
            Id = request.Registrator.UserId,
            HealthCenterId = request.Registrator.HealthCenterId,
            Status = true
        };

        _repository.Registrator.CreateEntity(RegistratorEntity);

        await _repository.SaveAsync(cancellationToken);

        await _userManager.AddToRoleAsync(existingUser, "Registrator");

        await transaction.CommitAsync(cancellationToken);

        return _mapper.Map<RegistratorDto>(RegistratorEntity);
    }
}
