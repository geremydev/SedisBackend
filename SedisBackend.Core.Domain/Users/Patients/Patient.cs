namespace SedisBackend.Core.Domain.Users.Patients
{
    public class Patient : BasePerson
    {
        public string BloodType { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public int PrimaryCarePhysicianId { get; set; }
    }
}
