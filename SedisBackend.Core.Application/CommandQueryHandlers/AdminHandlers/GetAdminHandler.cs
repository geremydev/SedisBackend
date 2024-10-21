using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Users.Admins;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.AdminCommandHandlers;

public sealed record GetAdminQuery(Guid Id, bool TrackChanges) : IRequest<AdminDto>;

internal sealed class GetAdminHandler : IRequestHandler<GetAdminQuery, AdminDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetAdminHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AdminDto> Handle(GetAdminQuery request, CancellationToken cancellationToken)
    {
        var admin = await _repository.Admin.GetEntityAsync(request.Id, request.TrackChanges);
        if (admin is null)
            throw new EntityNotFoundException(request.Id);

        return _mapper.Map<AdminDto>(admin);
    }
}
