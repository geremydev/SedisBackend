using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Vaccines;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.VaccineCommandHandlers;

public sealed record GetVaccineQuery(Guid Id, bool TrackChanges) : IRequest<VaccineDto>;

internal sealed class GetVaccineHandler : IRequestHandler<GetVaccineQuery, VaccineDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetVaccineHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<VaccineDto> Handle(GetVaccineQuery request, CancellationToken cancellationToken)
    {
        var vaccine = await _repository.Vaccine.GetEntityAsync(request.Id, request.TrackChanges);
        if (vaccine is null)
            throw new EntityNotFoundException(request.Id);

        return _mapper.Map<VaccineDto>(vaccine);
    }
}
