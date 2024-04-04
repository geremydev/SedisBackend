using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Domain.Users
{
    public class BasePerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdCard { get; set; }
        public bool IsActive { get; set; }
        public DateTime Birthdate { get; set; }
        public char Sex { get; set; }
    }
}
