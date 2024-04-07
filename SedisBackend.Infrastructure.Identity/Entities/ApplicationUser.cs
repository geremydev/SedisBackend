using Microsoft.AspNetCore.Identity;
using SedisBackend.Infrastructure.Identity.Relation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Infrastructure.Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public List<UserEntityRelation> AssignedUsers { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
