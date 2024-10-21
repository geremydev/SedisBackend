using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Users.Assistants;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.AssistantCommandHandlers;

public sealed record UpdateAssistantCommand(Guid Id, AssistantForUpdateDto Assistant, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdateAssistantHandler : IRequestHandler<UpdateAssistantCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateAssistantHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateAssistantCommand request, CancellationToken cancellationToken)
    {
        var assistantEntity = await _repository.Assistant.GetEntityAsync(request.Id, request.TrackChanges);
        if (assistantEntity is null)
            throw new EntityNotFoundException(request.Id);

        _mapper.Map(request.Assistant, assistantEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
