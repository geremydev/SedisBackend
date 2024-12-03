using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Allergies;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.PatientIllness;
using SedisBackend.Core.Domain.DTO.Entities.PatientLabTestPrescription;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientIllnessHandlers;

public sealed record GetLabTestPrescriptionsByHealthCenterQuery(Guid HealthCenterId, bool TrackChanges) : IRequest<IEnumerable<PatientLabTestPrescriptionDto>>;

internal sealed class GetLabTestPrescriptionsByHealthCenterHandler : IRequestHandler<GetLabTestPrescriptionsByHealthCenterQuery, IEnumerable<PatientLabTestPrescriptionDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetLabTestPrescriptionsByHealthCenterHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PatientLabTestPrescriptionDto>> Handle(GetLabTestPrescriptionsByHealthCenterQuery request, CancellationToken cancellationToken)
    {
        var patientLabTests = await _repository.PatientLabTestPrescription.GetByHealthCenter(request.HealthCenterId, request.TrackChanges);
        if (patientLabTests is null || !patientLabTests.Any())
            throw new EntitiesNotFoundException();

        var patientAllergiesDot = _mapper.Map<IEnumerable<PatientLabTestPrescriptionDto>>(patientLabTests);
        return patientAllergiesDot;
    }
}

