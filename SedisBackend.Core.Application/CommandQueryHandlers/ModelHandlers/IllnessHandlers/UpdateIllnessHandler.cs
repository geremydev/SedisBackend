using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.IllnessHandlers;

public sealed record UpdateIllnessCommand(Guid Id, IllnessForUpdateDto Illness, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdateIllnessHandler : IRequestHandler<UpdateIllnessCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateIllnessHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateIllnessCommand request, CancellationToken cancellationToken)
    {
        var illnessEntity = await _repository.Illness.GetEntityAsync(request.Id, request.TrackChanges);
        if (illnessEntity is null)
            throw new EntityNotFoundException(request.Id);

        _mapper.Map(request.Illness, illnessEntity);
        _repository.Illness.UpdateEntity(illnessEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
