using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Vaccines;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.VaccineHandlers;

public sealed record GetVaccinesQuery(bool TrackChanges) : IRequest<IEnumerable<VaccineDto>>;

internal sealed class GetVaccinesHandler : IRequestHandler<GetVaccinesQuery, IEnumerable<VaccineDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetVaccinesHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<VaccineDto>> Handle(GetVaccinesQuery request, CancellationToken cancellationToken)
    {
        var Vaccines = await _repository.Vaccine.GetAllEntitiesAsync(request.TrackChanges);

        if (Vaccines is null || !Vaccines.Any())
            throw new EntitiesNotFoundException();

        var VaccinesDto = _mapper.Map<IEnumerable<VaccineDto>>(Vaccines);
        return VaccinesDto;
    }
}
