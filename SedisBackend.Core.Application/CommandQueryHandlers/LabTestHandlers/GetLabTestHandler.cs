using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Products.LabTest;
using SedisBackend.Core.Domain.Exceptions.EntitiesExceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.LabTestCommandHandlers;

public sealed record GetLabTestQuery(Guid Id, bool TrackChanges) : IRequest<LabTestDto>;

internal sealed class GetLabTestHandler : IRequestHandler<GetLabTestQuery, LabTestDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetLabTestHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<LabTestDto> Handle(GetLabTestQuery request, CancellationToken cancellationToken)
    {
        var labtest = await _repository.LabTest.GetEntityAsync(request.Id, request.TrackChanges);
        if (labtest is null)
            throw new LabTestNotFoundException(request.Id);

        var labtestDto = _mapper.Map<LabTestDto>(labtest);

        return labtestDto;
    }
}
