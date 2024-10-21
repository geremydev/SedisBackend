using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Allergies;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.AllergyCommandHandlers;

public sealed record UpdateAllergyCommand(Guid Id, AllergyForUpdateDto Allergy, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdateAllergyHandler : IRequestHandler<UpdateAllergyCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateAllergyHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateAllergyCommand request, CancellationToken cancellationToken)
    {
        var allergyEntity = await _repository.Allergy.GetEntityAsync(request.Id, request.TrackChanges);
        if (allergyEntity is null)
            throw new EntityNotFoundException(request.Id);

        _mapper.Map(request.Allergy, allergyEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
