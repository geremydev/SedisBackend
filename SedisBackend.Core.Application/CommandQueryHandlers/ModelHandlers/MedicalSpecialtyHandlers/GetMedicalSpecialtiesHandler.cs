using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_Specialty;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.MedicalSpecialtyHandlers;

public sealed record GetMedicalSpecialtiesQuery(bool TrackChanges) : IRequest<IEnumerable<MedicalSpecialtyDto>>;

internal sealed class GetMedicalSpecialtiesHandler : IRequestHandler<GetMedicalSpecialtiesQuery, IEnumerable<MedicalSpecialtyDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetMedicalSpecialtiesHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MedicalSpecialtyDto>> Handle(GetMedicalSpecialtiesQuery request, CancellationToken cancellationToken)
    {
        var MedicalSpecialtys = await _repository.MedicalSpecialty.GetAllEntitiesAsync(request.TrackChanges);

        if (MedicalSpecialtys is null || !MedicalSpecialtys.Any())
            throw new EntitiesNotFoundException();

        var MedicalSpecialtysDto = _mapper.Map<IEnumerable<MedicalSpecialtyDto>>(MedicalSpecialtys);
        return MedicalSpecialtysDto;
    }
}
