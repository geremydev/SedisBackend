using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.IllnessHandlers;

public sealed record GetIllnessesQuery(bool TrackChanges) : IRequest<IEnumerable<IllnessDto>>;

internal sealed class GetIllnessesHandler : IRequestHandler<GetIllnessesQuery, IEnumerable<IllnessDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetIllnessesHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<IllnessDto>> Handle(GetIllnessesQuery request, CancellationToken cancellationToken)
    {
        var Illnesss = await _repository.Illness.GetAllEntitiesAsync(request.TrackChanges);

        if (Illnesss is null || !Illnesss.Any())
            throw new EntitiesNotFoundException();

        var IllnesssDto = _mapper.Map<IEnumerable<IllnessDto>>(Illnesss);
        return IllnesssDto;
    }
}
