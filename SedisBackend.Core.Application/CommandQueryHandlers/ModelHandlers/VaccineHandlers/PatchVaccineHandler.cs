using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Vaccines;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_History.Vaccines;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.VaccineHandlers;

public sealed record PatchVaccineCommand(Guid Id, bool TrackChanges, JsonPatchDocument<VaccineForUpdateDto> PatchDoc)
    : IRequest<(VaccineForUpdateDto VaccineToPatch, Vaccine VaccineEntity)>;

internal sealed class PatchVaccineHandler
    : IRequestHandler<PatchVaccineCommand, (VaccineForUpdateDto VaccineToPatch, Vaccine VaccineEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public PatchVaccineHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(VaccineForUpdateDto VaccineToPatch, Vaccine VaccineEntity)> Handle(
        PatchVaccineCommand request, CancellationToken cancellationToken)
    {
        var VaccineEntity = await _repository.Vaccine.GetEntityAsync(request.Id, request.TrackChanges);
        if (VaccineEntity is null)
            throw new EntityNotFoundException(request.Id);

        var VaccineToPatch = _mapper.Map<VaccineForUpdateDto>(VaccineEntity);
        request.PatchDoc.ApplyTo(VaccineToPatch);

        _mapper.Map(VaccineToPatch, VaccineEntity);
        await _repository.SaveAsync(cancellationToken);

        return (VaccineToPatch, VaccineEntity);
    }
}
