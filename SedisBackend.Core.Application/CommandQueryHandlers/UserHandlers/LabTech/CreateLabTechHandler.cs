using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.DTO.Entities.Users.LabTech;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.LabTechHandlers;

public sealed record CreateLabTechCommand(LabTechForCreationDto LabTech) : IRequest<LabTechDto>;

internal sealed class CreateRegistratorHandler : IRequestHandler<CreateLabTechCommand, LabTechDto>
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

    public async Task<LabTechDto> Handle(CreateLabTechCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await _repository.BeginTransactionAsync(cancellationToken);

        // Validar que el usuario exista
        var existingUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == request.LabTech.UserId);

        if (existingUser == null)
        {
            throw new UserNotFoundException(request.LabTech.UserId.ToString());
        }


        var LabTechEntity = new LabTech
        {
            Id = request.LabTech.UserId,
            HealthCenterId = request.LabTech.HealthCenterId,
            Status = true
        };

        _repository.LabTech.CreateEntity(LabTechEntity);

        await _repository.SaveAsync(cancellationToken);

        await _userManager.AddToRoleAsync(existingUser, "LabTech");

        await transaction.CommitAsync(cancellationToken);

        return _mapper.Map<LabTechDto>(LabTechEntity);
    }
}
