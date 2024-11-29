using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Users.Registrator;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.RegistratorHandlers;

public sealed record GetRegistratorQuery(Guid Id, bool TrackChanges) : IRequest<RegistratorDto>;

internal sealed class GetRegistratorHandler : IRequestHandler<GetRegistratorQuery, RegistratorDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetRegistratorHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<RegistratorDto> Handle(GetRegistratorQuery request, CancellationToken cancellationToken)
    {
        var Registrator = await _repository.Registrator.GetEntityAsync(request.Id, request.TrackChanges);

        if (Registrator is null)
            throw new EntityNotFoundException(request.Id);

        return _mapper.Map<RegistratorDto>(Registrator);
    }
}
