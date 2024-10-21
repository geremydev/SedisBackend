using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Family_History;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.FamilyHistoryCommandHandlers;

public sealed record GetFamilyHistoryQuery(Guid Id, bool TrackChanges) : IRequest<FamilyHistoryDto>;

internal sealed class GetFamilyHistoryHandler : IRequestHandler<GetFamilyHistoryQuery, FamilyHistoryDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetFamilyHistoryHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<FamilyHistoryDto> Handle(GetFamilyHistoryQuery request, CancellationToken cancellationToken)
    {
        var familyHistory = await _repository.FamilyHistory.GetEntityAsync(request.Id, request.TrackChanges);
        if (familyHistory is null)
            throw new EntityNotFoundException(request.Id);

        return _mapper.Map<FamilyHistoryDto>(familyHistory);
    }
}
