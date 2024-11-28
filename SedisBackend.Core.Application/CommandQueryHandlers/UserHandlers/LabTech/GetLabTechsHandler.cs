using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Users.LabTech;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.LabTechHandlers;

public sealed record GetLabTechsQuery(bool TrackChanges) : IRequest<IEnumerable<LabTechDto>>;

internal sealed class GetLabTechsHandler : IRequestHandler<GetLabTechsQuery, IEnumerable<LabTechDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetLabTechsHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LabTechDto>> Handle(GetLabTechsQuery request, CancellationToken cancellationToken)
    {
        var LabTechs = await _repository.LabTech.GetAllEntitiesAsync(request.TrackChanges);

        if (LabTechs is null || !LabTechs.Any())
            throw new EntitiesNotFoundException();

        var LabTechsDto = _mapper.Map<IEnumerable<LabTechDto>>(LabTechs);
        return LabTechsDto;
    }
}
