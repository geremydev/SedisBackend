using Microsoft.Extensions.DependencyInjection;
using SedisBackend.Core.Application.Interfaces.Services.Base;
using SedisBackend.Core.Application.Interfaces.Services;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Application.Services;
using System.Reflection;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Patients;
using SedisBackend.Core.Application.Services.Domain_Services.Users.Patients;

namespace SedisBackend.Core.Application.IOC
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            #region Services
            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IUserService, UserService>();
            #endregion
        }
    }
}
