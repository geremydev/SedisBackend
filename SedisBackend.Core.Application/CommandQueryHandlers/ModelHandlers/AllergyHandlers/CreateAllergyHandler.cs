using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Allergies;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_History.Allergies;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.AllergyHandlers;

public sealed record CreateAllergyCommand(AllergyForCreationDto allergy) : IRequest<AllergyDto>;

internal sealed class CreateAllergyHandler : IRequestHandler<CreateAllergyCommand, AllergyDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateAllergyHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AllergyDto> Handle(CreateAllergyCommand request, CancellationToken cancellationToken)
    {
        var allergyEntity = _mapper.Map<Allergy>(request.allergy);
        _repository.Allergy.CreateEntity(allergyEntity);
        await _repository.SaveAsync(cancellationToken);

        return _mapper.Map<AllergyDto>(allergyEntity);
    }
}
