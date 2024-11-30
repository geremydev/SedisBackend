using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Discapacity_Condition;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.DiscapacityHandlers;

public sealed record CreateDiscapacityCommand(DiscapacityForCreationDto discapacity) : IRequest<DiscapacityDto>;

internal sealed class CreateDiscapacityHandler : IRequestHandler<CreateDiscapacityCommand, DiscapacityDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateDiscapacityHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DiscapacityDto> Handle(CreateDiscapacityCommand request, CancellationToken cancellationToken)
    {
        var discapacityEntity = _mapper.Map<Discapacity>(request.discapacity);
        _repository.Discapacity.CreateEntity(discapacityEntity);
        await _repository.SaveAsync(cancellationToken);

        return _mapper.Map<DiscapacityDto>(discapacityEntity);
    }
}
