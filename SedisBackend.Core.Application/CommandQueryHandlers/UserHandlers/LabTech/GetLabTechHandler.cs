using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Users.LabTech;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.LabTechHandlers;

public sealed record GetLabTechQuery(Guid Id, bool TrackChanges) : IRequest<LabTechDto>;

internal sealed class GetLabTechHandler : IRequestHandler<GetLabTechQuery, LabTechDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetLabTechHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<LabTechDto> Handle(GetLabTechQuery request, CancellationToken cancellationToken)
    {
        var LabTech = await _repository.LabTech.GetEntityAsync(request.Id, request.TrackChanges);

        if (LabTech is null)
            throw new EntityNotFoundException(request.Id);

        return _mapper.Map<LabTechDto>(LabTech);
    }
}
