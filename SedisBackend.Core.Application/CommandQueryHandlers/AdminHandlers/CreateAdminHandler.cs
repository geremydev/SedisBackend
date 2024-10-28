using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.DTO.Entities.Users.Admins;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Enums;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.AdminCommandHandlers;

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

        // Separar lo del numero de telefono luego si es necesario porque realmente se pueden tener varios
        var existingUser = await _userManager.Users.FirstOrDefaultAsync(u => u.CardId == request.admin.CardId || u.PhoneNumber == request.admin.PhoneNumber);

        if (existingUser != null)
        {
            throw new UserExistsException(existingUser.CardId);
        }

        SexEnum sex;

        if (Enum.TryParse<SexEnum>(request.admin.Sex.ToString(), out sex))
        {
            var userEntity = new User
            {
                FirstName = request.admin.FirstName,
                LastName = request.admin.LastName,
                CardId = request.admin.CardId,
                IsActive = true,
                Birthdate = request.admin.Birthdate,
                Sex = sex,
                UserName = null,
                Email = request.admin.Email,
                PhoneNumber = request.admin.PhoneNumber,
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                ImageUrl = request.admin.ImageUrl
            };

            var userCreationResult = await _userManager.CreateAsync(userEntity, request.admin.Password);

            if (!userCreationResult.Succeeded)
            {
                var errorMessages = string.Join(", ", userCreationResult.Errors.Select(e => e.Description));
                throw new TransactionFailedException($"Error inserting an admin: {errorMessages}");
            }

            await _userManager.AddToRoleAsync(userEntity, RolesEnum.Admin.ToString());

            var adminEntity = new Admin
            {
                Id = userEntity.Id,
                HealthCenterId = request.admin.HealthCenterId
            };

            _repository.Admin.CreateEntity(adminEntity);

            await _repository.SaveAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            return _mapper.Map<AdminDto>(adminEntity);
        }
        else
        {
            throw new ArgumentException("Invalid sex value");
        }
    }
}
