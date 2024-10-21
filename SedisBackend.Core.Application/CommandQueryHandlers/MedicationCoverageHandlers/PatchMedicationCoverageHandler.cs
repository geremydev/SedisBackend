using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SedisBackend.Core.Domain.DTO.Entities.Medical_Insurance.MedicationCoverageDTO;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_Insurance;

namespace SedisBackend.Core.Application.CommandQueryHandlers.MedicationCoverageHandlers;

public sealed record PatchMedicationCoverageCommand(Guid Id, bool TrackChanges, JsonPatchDocument<MedicationCoverageForUpdateDto> PatchDoc)
    : IRequest<(MedicationCoverageForUpdateDto MedicationCoverageToPatch, MedicationCoverage MedicationCoverageEntity)>;

internal sealed class PatchMedicationCoverageHandler
    : IRequestHandler<PatchMedicationCoverageCommand, (MedicationCoverageForUpdateDto MedicationCoverageToPatch, MedicationCoverage MedicationCoverageEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public PatchMedicationCoverageHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(MedicationCoverageForUpdateDto MedicationCoverageToPatch, MedicationCoverage MedicationCoverageEntity)> Handle(
        PatchMedicationCoverageCommand request, CancellationToken cancellationToken)
    {
        var MedicationCoverageEntity = await _repository.MedicationCoverage.GetEntityAsync(request.Id, request.TrackChanges);
        if (MedicationCoverageEntity is null)
            throw new EntityNotFoundException(request.Id);

        var MedicationCoverageToPatch = _mapper.Map<MedicationCoverageForUpdateDto>(MedicationCoverageEntity);
        request.PatchDoc.ApplyTo(MedicationCoverageToPatch);

        _mapper.Map(MedicationCoverageToPatch, MedicationCoverageEntity);
        await _repository.SaveAsync(cancellationToken);

        return (MedicationCoverageToPatch, MedicationCoverageEntity);
    }
}
