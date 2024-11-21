using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SedisBackend.Core.Domain.Entities.Users;

namespace SedisBackend.Infrastructure.Persistence.Services;
public class UserManager : UserManager<User>
{
    public UserManager(
        IUserStore<User> store, 
        IOptions<IdentityOptions> optionsAccessor, 
        IPasswordHasher<User> passwordHasher, 
        IEnumerable<IUserValidator<User>> userValidators, 
        IEnumerable<IPasswordValidator<User>> passwordValidators, 
        ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, 
        IServiceProvider services, 
        ILogger<UserManager<User>> logger) 
        : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
    }

    public override async Task<IdentityResult> RemoveFromRolesAsync(User user, IEnumerable<string> roles)
    {
       var result = await base.RemoveFromRolesAsync(user, roles);
        return result;
    }
}
