using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.DTO.Entities.Users.Admins;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.AdminHandlers;

public sealed record CreateAdminCommand(AdminForCreationDto admin) : IRequest<AdminDto>;

internal sealed class CreateAdminHandler : IRequestHandler<CreateAdminCommand, AdminDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public CreateAdminHandler(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager)
    {
        _repository = repository;
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<AdminDto> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await _repository.BeginTransactionAsync(cancellationToken);

        // Validar que el usuario exista
        var existingUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == request.admin.UserId);

        if (existingUser == null)
        {
            throw new UserNotFoundException(request.admin.UserId.ToString());
        }


        var adminEntity = new Admin
        {
            Id = request.admin.UserId,
            HealthCenterId = request.admin.HealthCenterId,
            Status = true
        };

        _repository.Admin.CreateEntity(adminEntity);

        await _repository.SaveAsync(cancellationToken);

        await _userManager.AddToRoleAsync(existingUser, "admin");

        await transaction.CommitAsync(cancellationToken);

        return _mapper.Map<AdminDto>(adminEntity);
    }
}
