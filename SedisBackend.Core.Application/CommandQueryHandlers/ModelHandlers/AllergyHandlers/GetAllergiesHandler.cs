using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Allergies;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.AllergyHandlers;

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
        var allergies = await _repository.Allergy.GetAllEntitiesAsync(request.TrackChanges);

        if (allergies is null || !allergies.Any())
            throw new EntitiesNotFoundException();

        var allergiesDto = _mapper.Map<IEnumerable<AllergyDto>>(allergies);
        return allergiesDto;
    }
}
