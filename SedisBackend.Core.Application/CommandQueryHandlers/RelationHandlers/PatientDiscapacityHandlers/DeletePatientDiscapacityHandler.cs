using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.PatientDiscapacity;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientDiscapacityHandlers;

public sealed record DeletePatientDiscapacityCommand(Guid patientId, Guid DiscapacityId, bool TrackChanges) : IRequest<Unit>;

public class DeletePatientDiscapacityHandler
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public DeletePatientDiscapacityHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

        public async Task Handle(DeletePatientDiscapacityCommand request, CancellationToken cancellationToken)
    {
        var patientDiscapacity = await _repository.PatientDiscapacity.GetEntityAsync(request.patientId, request.DiscapacityId, request.TrackChanges);
        if (patientDiscapacity is null)
            throw new EntityNotFoundException(request.DiscapacityId);
        patientDiscapacity.Status = false;
        _repository.PatientDiscapacity.UpdateEntity(patientDiscapacity);
        await _repository.SaveAsync(cancellationToken);
    }
}
