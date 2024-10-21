using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using SedisBackend.Core.Domain.DTO.Entities.Products.LabTest;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Loggers;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.LabTestCommandHandlers;

public sealed record UpdateLabTestCommand(Guid Id, LabTestForUpdateDto LabTest, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdateLabTestHandler : IRequestHandler<UpdateLabTestCommand, Unit>
{
    private readonly ILoggerManager _logger; // Injecting logger
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateLabTestHandler(IRepositoryManager repository, IMapper mapper, ILoggerManager loggerManager, IHttpContextAccessor httpContext)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateLabTestCommand request, CancellationToken cancellationToken)
    {
        var labtestEntity = await _repository.LabTest.GetEntityAsync(request.Id, request.TrackChanges);
        if (labtestEntity is null)
            throw new EntityNotFoundException(request.Id);

        _mapper.Map(request.LabTest, labtestEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
