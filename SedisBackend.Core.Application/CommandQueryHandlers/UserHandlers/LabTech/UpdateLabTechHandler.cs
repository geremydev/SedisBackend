using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Domain.DTO.Entities.Users.LabTech;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.LabTechHandlers;

public sealed record UpdateLabTechCommand(Guid Id, LabTechForUpdateDto LabTech, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdateRegistratorHandler : IRequestHandler<UpdateLabTechCommand, Unit>
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

    public async Task<Unit> Handle(UpdateLabTechCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await _repository.BeginTransactionAsync(cancellationToken);

        var existingUser = await _userManager.FindByIdAsync(request.Id.ToString());

        if (existingUser is null)
            throw new EntityNotFoundException(request.Id);

        var LabTechEntity = await _repository.LabTech.GetEntityAsync(request.Id, true);
        LabTechEntity.HealthCenterId = request.LabTech.HealthCenterId;
        if (LabTechEntity.Status != request.LabTech.Status)
        {
            LabTechEntity.Status = request.LabTech.Status;
            if (LabTechEntity.Status)
                await _userManager.AddToRoleAsync(existingUser, "LabTech");
            else
                await _userManager.RemoveFromRoleAsync(existingUser, "LabTech");
        }

        await _repository.SaveAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);


        return Unit.Value;
    }
}
