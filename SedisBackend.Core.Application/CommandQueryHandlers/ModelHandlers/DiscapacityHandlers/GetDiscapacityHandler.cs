using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.DiscapacityHandlers;

public sealed record GetDiscapacityQuery(Guid Id, bool TrackChanges) : IRequest<DiscapacityDto>;

internal sealed class GetDiscapacityHandler : IRequestHandler<GetDiscapacityQuery, DiscapacityDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetDiscapacityHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DiscapacityDto> Handle(GetDiscapacityQuery request, CancellationToken cancellationToken)
    {
        var discapacity = await _repository.Discapacity.GetEntityAsync(request.Id, request.TrackChanges);
        if (discapacity is null)
            throw new EntityNotFoundException(request.Id);

        return _mapper.Map<DiscapacityDto>(discapacity);
    }
}
