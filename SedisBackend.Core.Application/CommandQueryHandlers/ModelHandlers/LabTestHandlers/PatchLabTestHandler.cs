using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SedisBackend.Core.Domain.DTO.Entities.Products.LabTest;
using SedisBackend.Core.Domain.Entities.Models.Products;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.LabTestHandlers;
public sealed record PatchLabTestCommand(Guid Id, bool TrackChanges, JsonPatchDocument<LabTestForUpdateDto> PatchDoc)
    : IRequest<(LabTestForUpdateDto labtestToPatch, LabTest labtestEntity)>;

internal sealed class PatchLabTestHandler
    : IRequestHandler<PatchLabTestCommand, (LabTestForUpdateDto labtestToPatch, LabTest labtestEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public PatchLabTestHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(LabTestForUpdateDto labtestToPatch, LabTest labtestEntity)> Handle(
        PatchLabTestCommand request, CancellationToken cancellationToken)
    {
        var labtestEntity = await _repository.LabTest.GetEntityAsync(request.Id, request.TrackChanges);
        if (labtestEntity is null)
            throw new EntityNotFoundException(request.Id);

        var labtestToPatch = _mapper.Map<LabTestForUpdateDto>(labtestEntity);

        request.PatchDoc.ApplyTo(labtestToPatch);

        _mapper.Map(labtestToPatch, labtestEntity);

        await _repository.SaveAsync(cancellationToken);

        return (labtestToPatch, labtestEntity);
    }
}
