using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLog;
using SedisBackend.Core.Application.Interfaces.Loggers;
using SedisBackend.Core.Application.IOC;
using SedisBackend.Infrastructure.Identity.Entities;
using SedisBackend.Infrastructure.Identity.IOC;
using SedisBackend.Infrastructure.Identity.Seeds;
using SedisBackend.Infrastructure.Persistence.IOC;
using SedisBackend.Infrastructure.Shared;
using SedisBackend.WebApi.Extensions;
using WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();

builder.Services.AddHttpClient();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();

builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.IdentityLayerRegistration(builder.Configuration);
builder.Services.AddSharedInfrastructure(builder.Configuration);
builder.Services.AddApiVersioningExtension();
builder.Services.AddApplicationLayer();
builder.Services.AddSwaggerExtension(builder.Configuration);

builder.Services.AddHealthChecks();
builder.Services.AddSwaggerGen();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSession();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddMvc();

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ProducesAttribute("application/json"));
}).ConfigureApiBehaviorOptions(options =>
{
    options.SuppressConsumesConstraintForFormFileParameters = true;
    options.SuppressMapClientErrors = true;
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        await DefaultRoles.SeedAsync(userManager, roleManager);
        await AdminUser.SeedAsync(userManager, roleManager);
        await PatientUser.SeedAsync(userManager, roleManager);
        await AssistantUser.SeedAsync(userManager, roleManager);
        await SuperAdmin.SeedAsync(userManager, roleManager);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
}

if (app.Environment.IsProduction())
    app.UseHsts();

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("SedisPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.UseSwaggerExtension();
app.UseHealthChecks("/health");
app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
