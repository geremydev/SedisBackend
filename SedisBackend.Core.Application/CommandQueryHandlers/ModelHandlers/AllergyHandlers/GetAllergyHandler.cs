using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Allergies;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.AllergyHandlers;

public sealed record GetAllergyQuery(Guid Id, bool TrackChanges) : IRequest<AllergyDto>;

internal sealed class GetAllergyHandler : IRequestHandler<GetAllergyQuery, AllergyDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetAllergyHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AllergyDto> Handle(GetAllergyQuery request, CancellationToken cancellationToken)
    {
        var allergy = await _repository.Allergy.GetEntityAsync(request.Id, request.TrackChanges);
        if (allergy is null)
            throw new EntityNotFoundException(request.Id);

        return _mapper.Map<AllergyDto>(allergy);
    }
}
