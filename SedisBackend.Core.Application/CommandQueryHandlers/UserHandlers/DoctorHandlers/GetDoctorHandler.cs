using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Users.Doctors;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.DoctorHandlers;

public sealed record GetDoctorQuery(Guid Id, bool TrackChanges) : IRequest<DoctorDto>;

internal sealed class GetDoctorHandler : IRequestHandler<GetDoctorQuery, DoctorDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetDoctorHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DoctorDto> Handle(GetDoctorQuery request, CancellationToken cancellationToken)
    {
        var doctor = await _repository.Doctor.GetEntityAsync(request.Id, request.TrackChanges);
        if (doctor is null)
            throw new EntityNotFoundException(request.Id);

        return _mapper.Map<DoctorDto>(doctor);
    }
}
