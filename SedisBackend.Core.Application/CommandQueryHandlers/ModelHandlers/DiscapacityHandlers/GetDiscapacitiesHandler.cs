using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.DiscapacityHandlers;

public sealed record GetDiscapacitiesQuery(bool TrackChanges) : IRequest<IEnumerable<DiscapacityDto>>;

internal sealed class GetDiscapacitiesHandler : IRequestHandler<GetDiscapacitiesQuery, IEnumerable<DiscapacityDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetDiscapacitiesHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DiscapacityDto>> Handle(GetDiscapacitiesQuery request, CancellationToken cancellationToken)
    {
        var Discapacitys = await _repository.Discapacity.GetAllEntitiesAsync(request.TrackChanges);

        if (Discapacitys is null || !Discapacitys.Any())
            throw new EntitiesNotFoundException();

        var DiscapacitysDto = _mapper.Map<IEnumerable<DiscapacityDto>>(Discapacitys);
        return DiscapacitysDto;
    }
}
