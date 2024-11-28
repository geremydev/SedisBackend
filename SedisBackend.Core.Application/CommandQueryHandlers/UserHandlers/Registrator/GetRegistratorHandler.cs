using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Users.Registrator;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.AdminHandlers;

public sealed record GetRegistratorQuery(Guid Id, bool TrackChanges) : IRequest<RegistratorDto>;

internal sealed class RegistratorHandler : IRequestHandler<GetRegistratorQuery, RegistratorDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public RegistratorHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<RegistratorDto> Handle(GetRegistratorQuery request, CancellationToken cancellationToken)
    {
        var admin = await _repository.Admin.GetEntityAsync(request.Id, request.TrackChanges);

        if (admin is null)
            throw new EntityNotFoundException(request.Id);

        return _mapper.Map<RegistratorDto>(admin);
    }
}
