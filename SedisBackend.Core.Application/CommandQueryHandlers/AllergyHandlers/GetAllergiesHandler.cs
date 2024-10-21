using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Allergies;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.AllergyHandlers;

public sealed record GetAllergiesQuery(bool TrackChanges) : IRequest<IEnumerable<AllergyDto>>;

internal sealed class GetAllergiesHandler : IRequestHandler<GetAllergiesQuery, IEnumerable<AllergyDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetAllergiesHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AllergyDto>> Handle(GetAllergiesQuery request, CancellationToken cancellationToken)
    {
        var Allergys = await _repository.Allergy.GetAllEntitiesAsync(request.TrackChanges);

        if (Allergys is null || !Allergys.Any())
            throw new EntitiesNotFoundException();

        var AllergysDto = _mapper.Map<IEnumerable<AllergyDto>>(Allergys);
        return AllergysDto;
    }
}
