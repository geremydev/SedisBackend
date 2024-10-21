using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Products.LabTest;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.LabTestHandlers;

public sealed record GetLabTestsQuery(bool TrackChanges) : IRequest<IEnumerable<LabTestDto>>;

internal sealed class GetLabtestsHandler : IRequestHandler<GetLabTestsQuery, IEnumerable<LabTestDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetLabtestsHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LabTestDto>> Handle(GetLabTestsQuery request,
        CancellationToken cancellationToken)
    {
        var labtests = await _repository.LabTest.GetAllEntitiesAsync(request.TrackChanges);

        if (labtests is null || !labtests.Any())
            throw new EntitiesNotFoundException();

        var labtestsDto = _mapper.Map<IEnumerable<LabTestDto>>(labtests);

        return labtestsDto;
    }
}
