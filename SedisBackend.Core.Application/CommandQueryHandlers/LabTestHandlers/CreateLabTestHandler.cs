using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Products.LabTest;
using SedisBackend.Core.Domain.Entities.Models.Products;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.LabTestCommandHandlers;

public sealed record CreateLabTestCommand(LabTestForCreationDto Labtest) : IRequest<LabTestDto>;

internal sealed class CreateLabTestHandler : IRequestHandler<CreateLabTestCommand, LabTestDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateLabTestHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<LabTestDto> Handle(CreateLabTestCommand request, CancellationToken cancellationToken)
    {
        var labtestEntity = _mapper.Map<LabTest>(request.Labtest);

        _repository.LabTest.CreateEntity(labtestEntity);
        await _repository.SaveAsync(cancellationToken);

        var labtestToReturn = _mapper.Map<LabTestDto>(labtestEntity);

        return labtestToReturn;
    }
}
