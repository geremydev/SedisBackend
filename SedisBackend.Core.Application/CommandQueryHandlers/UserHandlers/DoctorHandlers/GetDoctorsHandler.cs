using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Users.Doctors;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.DoctorHandlers;

public sealed record GetDoctorsQuery(bool TrackChanges) : IRequest<IEnumerable<DoctorDto>>;

internal sealed class GetDoctorsHandler : IRequestHandler<GetDoctorsQuery, IEnumerable<DoctorDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetDoctorsHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DoctorDto>> Handle(GetDoctorsQuery request, CancellationToken cancellationToken)
    {
        var Doctors = await _repository.Doctor.GetAllEntitiesAsync(request.TrackChanges);

        if (Doctors is null || !Doctors.Any())
            throw new EntitiesNotFoundException();

        var DoctorsDto = _mapper.Map<IEnumerable<DoctorDto>>(Doctors);
        return DoctorsDto;
    }
}
