namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Vaccines
{
    public class SaveVaccineDto
    {
        public string Name { get; set; }
        public string Disease { get; set; }
        public int Doses { get; set; } // Total number of doses required for the vaccination
        public string Laboratory { get; set; } // Manufacturer of the vaccine
    }
}
