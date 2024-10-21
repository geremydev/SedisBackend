using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Users.Admins;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.AdminCommandHandlers;

public sealed record UpdateAdminCommand(Guid Id, AdminForUpdateDto Admin, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdateAdminHandler : IRequestHandler<UpdateAdminCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateAdminHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
    {
        var adminEntity = await _repository.Admin.GetEntityAsync(request.Id, request.TrackChanges);
        if (adminEntity is null)
            throw new EntityNotFoundException(request.Id);

        _mapper.Map(request.Admin, adminEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
