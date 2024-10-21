using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Prescriptions;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.PrescriptionCommandHandlers;

public sealed record GetPrescriptionQuery(Guid Id, bool TrackChanges) : IRequest<PrescriptionDto>;

internal sealed class GetPrescriptionHandler : IRequestHandler<GetPrescriptionQuery, PrescriptionDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetPrescriptionHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PrescriptionDto> Handle(GetPrescriptionQuery request, CancellationToken cancellationToken)
    {
        var prescription = await _repository.Prescription.GetEntityAsync(request.Id, request.TrackChanges);
        if (prescription is null)
            throw new EntityNotFoundException(request.Id);

        return _mapper.Map<PrescriptionDto>(prescription);
    }
}
