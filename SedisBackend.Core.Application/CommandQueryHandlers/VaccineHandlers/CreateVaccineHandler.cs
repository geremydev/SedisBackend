using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Vaccines;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_History.Vaccines;

namespace SedisBackend.Core.Application.CommandHandlers.VaccineCommandHandlers;

public sealed record CreateVaccineCommand(VaccineForCreationDto vaccine) : IRequest<VaccineDto>;

internal sealed class CreateVaccineHandler : IRequestHandler<CreateVaccineCommand, VaccineDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateVaccineHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<VaccineDto> Handle(CreateVaccineCommand request, CancellationToken cancellationToken)
    {
        var vaccineEntity = _mapper.Map<Vaccine>(request.vaccine);
        _repository.Vaccine.CreateEntity(vaccineEntity);
        await _repository.SaveAsync(cancellationToken);

        return _mapper.Map<VaccineDto>(vaccineEntity);
    }
}
