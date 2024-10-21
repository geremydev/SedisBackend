using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Users.Doctors;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.DoctorCommandHandlers;

public sealed record UpdateDoctorCommand(Guid Id, DoctorForUpdateDto Doctor, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdateDoctorHandler : IRequestHandler<UpdateDoctorCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateDoctorHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctorEntity = await _repository.Doctor.GetEntityAsync(request.Id, request.TrackChanges);
        if (doctorEntity is null)
            throw new EntityNotFoundException(request.Id);

        _mapper.Map(request.Doctor, doctorEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
