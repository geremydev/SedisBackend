using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Products.Medication;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.MedicationHandlers;

public sealed record GetMedicationQuery(Guid Id, bool TrackChanges) : IRequest<MedicationDto>;

internal sealed class GetMedicationHandler : IRequestHandler<GetMedicationQuery, MedicationDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetMedicationHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<MedicationDto> Handle(GetMedicationQuery request, CancellationToken cancellationToken)
    {
        var medication = await _repository.Medication.GetEntityAsync(request.Id, request.TrackChanges);
        if (medication is null)
            throw new EntityNotFoundException(request.Id);

        return _mapper.Map<MedicationDto>(medication);
    }
}
