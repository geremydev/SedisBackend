using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Domain.Users.Doctors
{
    public class DoctorMedicalSpeciality
    {
        //n->n relationship table between Doctor and MedicalSpecialisation
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int MedicalSpecialityId { get; set; }
        public MedicalSpeciality MedicalSpeciality { get; set; }
    }
}
