using Microsoft.IdentityModel.Tokens;
using SedisBackend.Core.Application.Interfaces.Services;
using SedisBackend.Core.Domain.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WebApi.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _config;
        private readonly JWTSettings _jwtSettings;

        public JwtMiddleware(RequestDelegate next, IConfiguration config, JWTSettings jwtSettings)
        {
            _next = next;
            _config = config;
            _jwtSettings = jwtSettings;
        }

        public async Task Invoke(HttpContext context, IAccountService accountService)
        {
            var token = context.Request.Cookies["auth_token"];

            if (token != null)
            {
                AttachUserToContext(context, accountService, token);
            }

            await _next(context);
        }

        private async Task AttachUserToContext(HttpContext context, IAccountService accountService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.First(x => x.Type == "uid").Value;

                // Attach user to context on successful JWT validation
                context.Items["User"] = await accountService.GetByIdAsync(userId);
            }
            catch
            {
                // Do nothing if the JWT validation fails
                // The request won't have access to secure routes
            }
        }
    }

}
