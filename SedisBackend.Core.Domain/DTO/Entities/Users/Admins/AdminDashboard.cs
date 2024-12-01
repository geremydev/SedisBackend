namespace SedisBackend.Core.Domain.DTO.Entities.Users.Admins;
public class AdminDashboard
{
    public int WorkingDoctors { get; set; }
    public int WorkingAssistants { get; set; }
    public int WorkingLabTechs { get; set; }
    public int TodaysAppointments { get; set; }
    public int TotalAppointments { get; set; }
}
