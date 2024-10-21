using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Prescriptions;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.PrescriptionHandlers;

public sealed record GetPrescriptionsQuery(bool TrackChanges) : IRequest<IEnumerable<PrescriptionDto>>;

internal sealed class GetPrescriptionsHandler : IRequestHandler<GetPrescriptionsQuery, IEnumerable<PrescriptionDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetPrescriptionsHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PrescriptionDto>> Handle(GetPrescriptionsQuery request, CancellationToken cancellationToken)
    {
        var Prescriptions = await _repository.Prescription.GetAllEntitiesAsync(request.TrackChanges);

        if (Prescriptions is null || !Prescriptions.Any())
            throw new EntitiesNotFoundException();

        var PrescriptionsDto = _mapper.Map<IEnumerable<PrescriptionDto>>(Prescriptions);
        return PrescriptionsDto;
    }
}
