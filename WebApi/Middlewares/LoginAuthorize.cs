using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Middlewares
{
    public class LoginAuthorize : IAsyncActionFilter
    {
        private readonly ValidateUserSession _userSession;

        public LoginAuthorize(ValidateUserSession validateUser)
        {
            _userSession = validateUser;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (_userSession.HasUser())
            {
                var controller = (UserController)context.Controller;
                context.Result = controller.RedirectToAction("index", "home");
            }
            else
            {
                await next();
            }
        }
    }
}
