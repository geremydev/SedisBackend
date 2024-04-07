using Microsoft.AspNetCore.Identity;
using SedisBackend.Infrastructure.Identity.Relation;

namespace SedisBackend.Infrastructure.Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public List<UserEntityRelation> AssignedUsers { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
