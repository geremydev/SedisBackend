using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.IllnessHandlers;

public sealed record GetIllnessQuery(Guid Id, bool TrackChanges) : IRequest<IllnessDto>;

internal sealed class GetIllnessHandler : IRequestHandler<GetIllnessQuery, IllnessDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetIllnessHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IllnessDto> Handle(GetIllnessQuery request, CancellationToken cancellationToken)
    {
        var illness = await _repository.Illness.GetEntityAsync(request.Id, request.TrackChanges);
        if (illness is null)
            throw new EntityNotFoundException(request.Id);

        return _mapper.Map<IllnessDto>(illness);
    }
}
