using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Domain.Users.Doctors
{
    public class Doctor : BasePerson
    {
        public List<DoctorMedicalSpeciality> Specialities { get; set; }
        public string HospitalAffiliation { get; set; }
        public string LicenseNumber { get; set; }
    }
}
