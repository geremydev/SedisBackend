using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Domain.DTO.Entities.Users.Admins;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Enums;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.AdminCommandHandlers;

public sealed record UpdateAdminCommand(Guid Id, AdminForUpdateDto Admin, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdateAdminHandler : IRequestHandler<UpdateAdminCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public UpdateAdminHandler(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager)
    {
        _repository = repository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<Unit> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await _repository.BeginTransactionAsync(cancellationToken);

        var existingUser = await _userManager.FindByIdAsync(request.Id.ToString());

        if (existingUser is null)
            throw new EntityNotFoundException(request.Id);

        var adminEntity = await _repository.Admin.GetEntityAsync(request.Id, true);


        adminEntity.HealthCenterId = request.Admin.HealthCenterId;

        await _repository.SaveAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
       

        return Unit.Value;
    }
}
