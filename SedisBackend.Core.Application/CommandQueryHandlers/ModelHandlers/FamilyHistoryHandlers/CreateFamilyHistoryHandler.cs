using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Family_History;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_History.Family_History;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.FamilyHistoryHandlers;

public sealed record CreateFamilyHistoryCommand(FamilyHistoryForCreationDto familyHistory) : IRequest<FamilyHistoryDto>;

internal sealed class CreateFamilyHistoryHandler : IRequestHandler<CreateFamilyHistoryCommand, FamilyHistoryDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateFamilyHistoryHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<FamilyHistoryDto> Handle(CreateFamilyHistoryCommand request, CancellationToken cancellationToken)
    {
        var familyHistoryEntity = _mapper.Map<FamilyHistory>(request.familyHistory);
        _repository.FamilyHistory.CreateEntity(familyHistoryEntity);
        await _repository.SaveAsync(cancellationToken);

        return _mapper.Map<FamilyHistoryDto>(familyHistoryEntity);
    }
}
