namespace WebApi.Middlewares;

public class CsrfProtectionMiddleware
{
    private readonly RequestDelegate _next;

    public CsrfProtectionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        // Check if the request is a POST request
        if (context.Request.Method == HttpMethods.Post)
        {
            // Check for CSRF token in headers
            if (!context.Request.Headers.TryGetValue("X-CSRF-Token", out var csrfToken))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("CSRF token is missing.");
                return;
            }

            // Validate CSRF token
            // Example: Compare with a value stored in the session
            //if (!IsValidCsrfToken(csrfToken))
            //{
            //    context.Response.StatusCode = StatusCodes.Status403Forbidden;
            //    await context.Response.WriteAsync("Invalid CSRF token.");
            //    return;
            //}
        }

        await _next(context);
    }
}
