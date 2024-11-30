using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Users.Registrator;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.RegistratorHandlers;

public sealed record GetRegistratorsQuery(bool TrackChanges) : IRequest<IEnumerable<RegistratorDto>>;

internal sealed class GetRegistratorsHandler : IRequestHandler<GetRegistratorsQuery, IEnumerable<RegistratorDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetRegistratorsHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RegistratorDto>> Handle(GetRegistratorsQuery request, CancellationToken cancellationToken)
    {
        var Registrators = await _repository.Registrator.GetAllEntitiesAsync(request.TrackChanges);

        if (Registrators is null || !Registrators.Any())
            throw new EntitiesNotFoundException();

        var RegistratorsDto = _mapper.Map<IEnumerable<RegistratorDto>>(Registrators);
        return RegistratorsDto;
    }
}
