using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.AssistantCommandHandlers;

public record DeleteAssistantCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeleteAssistantHandler : IRequestHandler<DeleteAssistantCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteAssistantHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteAssistantCommand request, CancellationToken cancellationToken)
    {
        var assistant = await _repository.Assistant.GetEntityAsync(request.Id, request.TrackChanges);
        if (assistant is null)
            throw new EntityNotFoundException(request.Id);

        _repository.Assistant.DeleteEntity(assistant);
        await _repository.SaveAsync(cancellationToken);
    }
}
