using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Users.Admins;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.AdminHandlers;

public sealed record GetAdminsQuery(bool TrackChanges) : IRequest<IEnumerable<AdminDto>>;

internal sealed class GetAdminsHandler : IRequestHandler<GetAdminsQuery, IEnumerable<AdminDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetAdminsHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AdminDto>> Handle(GetAdminsQuery request, CancellationToken cancellationToken)
    {
        var Admins = await _repository.Admin.GetAllEntitiesAsync(request.TrackChanges);

        if (Admins is null || !Admins.Any())
            throw new EntitiesNotFoundException();

        var AdminsDto = _mapper.Map<IEnumerable<AdminDto>>(Admins);
        return AdminsDto;
    }
}
