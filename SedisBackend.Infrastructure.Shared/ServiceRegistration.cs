using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SedisBackend.Core.Application.Interfaces.Services;
using SedisBackend.Core.Domain.Settings;
using SedisBackend.Infrastructure.Shared.Services;

namespace SedisBackend.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}
