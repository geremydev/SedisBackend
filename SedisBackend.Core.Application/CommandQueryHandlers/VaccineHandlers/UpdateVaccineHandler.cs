using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Vaccines;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.VaccineCommandHandlers;

public sealed record UpdateVaccineCommand(Guid Id, VaccineForUpdateDto Vaccine, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdateVaccineHandler : IRequestHandler<UpdateVaccineCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateVaccineHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateVaccineCommand request, CancellationToken cancellationToken)
    {
        var vaccineEntity = await _repository.Vaccine.GetEntityAsync(request.Id, request.TrackChanges);
        if (vaccineEntity is null)
            throw new EntityNotFoundException(request.Id);

        _mapper.Map(request.Vaccine, vaccineEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
