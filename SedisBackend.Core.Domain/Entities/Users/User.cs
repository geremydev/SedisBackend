using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Domain.Enums;

namespace SedisBackend.Core.Domain.Entities.Users;

public class User : IdentityUser<Guid>
{
    //private Guid _id;

    //public override Guid Id
    //{
    //    get
    //    {
    //        if (_id == Guid.Empty)
    //        {
    //            _id = Guid.NewGuid();
    //        }
    //        return _id;
    //    }
    //    set
    //    {
    //        _id = value;
    //    }
    //}

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CardId { get; set; }
    public bool IsActive { get; set; }
    public DateTime Birthdate { get; set; }
    public SexEnum Sex { get; set; }
    public string? ImageUrl { get; set; }
}
