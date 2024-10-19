namespace SedisBackend.Core.Domain.DTO.Entities.Users.Patients;

public class GetAllPatientsWithIncludeDto
{
    public List<string> Includes { get; set; }
}
