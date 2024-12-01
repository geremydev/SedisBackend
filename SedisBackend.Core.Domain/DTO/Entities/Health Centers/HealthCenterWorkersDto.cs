using SedisBackend.Core.Domain.DTO.Entities.Users.Assistants;
using SedisBackend.Core.Domain.DTO.Entities.Users.Doctors;
using SedisBackend.Core.Domain.DTO.Entities.Users.LabTech;

namespace SedisBackend.Core.Domain.DTO.Entities.Health_Centers;
public class HealthCenterWorkersDto
{
    public ICollection<DoctorDto> Doctors { get; set; }
    public ICollection<LabTechDto> LabTechs { get; set; }
    public ICollection<AssistantDto> Assistants { get; set; }

}
