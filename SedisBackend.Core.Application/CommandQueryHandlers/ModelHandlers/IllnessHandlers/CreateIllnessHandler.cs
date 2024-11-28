using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.IllnessHandlers;

public sealed record CreateIllnessCommand(IllnessForCreationDto illness) : IRequest<IllnessDto>;

internal sealed class CreateIllnessHandler : IRequestHandler<CreateIllnessCommand, IllnessDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateIllnessHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IllnessDto> Handle(CreateIllnessCommand request, CancellationToken cancellationToken)
    {
        var illnessEntity = _mapper.Map<Illness>(request.illness);
        _repository.Illness.CreateEntity(illnessEntity);
        await _repository.SaveAsync(cancellationToken);

        return _mapper.Map<IllnessDto>(illnessEntity);
    }
}
