using SedisBackend.Core.Application.Dtos.Identity_Dtos.Account;
using SedisBackend.Core.Application.Helpers;

namespace WebApi.Middlewares
{
    public class ValidateUserSession
    {
        private readonly IHttpContextAccessor httpContext;


        public ValidateUserSession(IHttpContextAccessor httpContextAccessor)
        {
            httpContext = httpContextAccessor;
        }

        public bool HasUser()
        {
            AuthenticationResponse vm = httpContext.HttpContext.Session.Get<AuthenticationResponse>("user");
            if (vm == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
