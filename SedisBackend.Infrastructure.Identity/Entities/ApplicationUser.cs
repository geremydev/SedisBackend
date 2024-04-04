using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Infrastructure.Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public List<int> AssignedUsersIds { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
