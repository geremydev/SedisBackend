using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Users.Admins;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.AdminCommandHandlers;

public sealed record CreateAdminCommand(AdminForCreationDto admin) : IRequest<AdminDto>;

internal sealed class CreateAdminHandler : IRequestHandler<CreateAdminCommand, AdminDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateAdminHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AdminDto> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
    {
        var adminEntity = _mapper.Map<Admin>(request.admin);
        _repository.Admin.CreateEntity(adminEntity);
        await _repository.SaveAsync(cancellationToken);

        return _mapper.Map<AdminDto>(adminEntity);
    }
}
