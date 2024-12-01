using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Health_Centers;
using SedisBackend.Core.Domain.DTO.Entities.Users.Admins;
using SedisBackend.Core.Domain.DTO.Entities.Users.Assistants;
using SedisBackend.Core.Domain.DTO.Entities.Users.Doctors;
using SedisBackend.Core.Domain.DTO.Entities.Users.LabTech;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.AdminHandlers;

public record GetAdminDashboardQuery(Guid Id) : IRequest<AdminDashboard>;
internal sealed class GetAdminDashboardHandler : IRequestHandler<GetAdminDashboardQuery, AdminDashboard>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetAdminDashboardHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AdminDashboard> Handle(GetAdminDashboardQuery request, CancellationToken cancellationToken)
    {
        var Dashboard = new AdminDashboard();

        var admin = await _repository.Admin.GetEntityAsync(request.Id, true);
        if (admin != null) {

            var result = new HealthCenterWorkersDto();
            var healthCenter = await _repository.HealthCenter.GetEntityAsync(admin.HealthCenterId, false);
            if (healthCenter != null)
            {
                Dashboard.WorkingAssistants = (_repository.Assistant.GetByHealthCenterId(admin.HealthCenterId)).Count();
                Dashboard.WorkingDoctors = (_repository.Doctor.GetByHealthCenterId(admin.HealthCenterId)).Count();
                Dashboard.WorkingLabTechs = (_repository.LabTech.GetByHealthCenterId(admin.HealthCenterId)).Count();
            }
            Dashboard.TotalAppointments = (await _repository.Appointment.GetAllEntitiesAsync(true)).Count();
        }

        return Dashboard;
    }
}