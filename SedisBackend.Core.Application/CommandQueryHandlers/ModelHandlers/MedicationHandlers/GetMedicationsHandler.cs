using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Products.Medication;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.MedicationHandlers;

public sealed record GetMedicationsQuery(bool TrackChanges) : IRequest<IEnumerable<MedicationDto>>;

internal sealed class GetMedicationsHandler : IRequestHandler<GetMedicationsQuery, IEnumerable<MedicationDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetMedicationsHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MedicationDto>> Handle(GetMedicationsQuery request, CancellationToken cancellationToken)
    {
        var Medications = await _repository.Medication.GetAllEntitiesAsync(request.TrackChanges);

        if (Medications is null || !Medications.Any())
            throw new EntitiesNotFoundException();

        var MedicationsDto = _mapper.Map<IEnumerable<MedicationDto>>(Medications);
        return MedicationsDto;
    }
}
