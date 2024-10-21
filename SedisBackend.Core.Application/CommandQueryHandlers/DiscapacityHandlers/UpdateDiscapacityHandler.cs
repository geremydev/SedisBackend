using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.DiscapacityCommandHandlers;

public sealed record UpdateDiscapacityCommand(Guid Id, DiscapacityForUpdateDto Discapacity, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdateDiscapacityHandler : IRequestHandler<UpdateDiscapacityCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateDiscapacityHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateDiscapacityCommand request, CancellationToken cancellationToken)
    {
        var discapacityEntity = await _repository.Discapacity.GetEntityAsync(request.Id, request.TrackChanges);
        if (discapacityEntity is null)
            throw new EntityNotFoundException(request.Id);

        _mapper.Map(request.Discapacity, discapacityEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
