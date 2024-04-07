using SedisBackend.Core.Domain.Users.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Doctors
{
    public class BaseMedicalSpeciality
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int MedicalSpecialityId { get; set; }
        public MedicalSpecialty MedicalSpecialty { get; set; }
    }
}
