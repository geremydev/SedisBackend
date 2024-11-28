using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.PatientDiscapacity;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientDiscapacityHandlers;

public sealed record UpdatePatientDiscapacityCommand(Guid Id, PatientDiscapacityForUpdateDto PatientDiscapacity, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdatePatientDiscapacityHandler : IRequestHandler<UpdatePatientDiscapacityCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdatePatientDiscapacityHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdatePatientDiscapacityCommand request, CancellationToken cancellationToken)
    {
        var patientDiscapacityEntity = await _repository.PatientDiscapacity.GetEntityAsync(request.PatientDiscapacity.PatientId, request.PatientDiscapacity.DiscapacityId, request.TrackChanges);
        if (patientDiscapacityEntity is null)
            throw new EntityNotFoundException(request.Id);

        _mapper.Map(request.PatientDiscapacity, patientDiscapacityEntity);
        _repository.PatientDiscapacity.UpdateEntity(patientDiscapacityEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
