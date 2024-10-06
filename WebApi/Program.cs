using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SedisBackend.Infrastructure.Identity.Entities;
using SedisBackend.Infrastructure.Identity.Seeds;
using SedisBackend.Infrastructure.Persistence.IOC;
using SedisBackend.WebApi.Extensions;
using SedisBackend.Core.Application.IOC;
using SedisBackend.Infrastructure.Identity.IOC;
using SedisBackend.Infrastructure.Shared;
using WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ProducesAttribute("application/json"));
}).ConfigureApiBehaviorOptions(options =>
{
    options.SuppressConsumesConstraintForFormFileParameters = true;
    options.SuppressMapClientErrors = true;
});

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

builder.Services.AddCors(options => options.AddPolicy("NextJS", policy =>
{
    policy.WithOrigins("http://localhost:3000")
          .AllowAnyHeader()
          .AllowAnyMethod()
          .WithMethods("POST", "OPTIONS")
          .AllowCredentials();
}));

//builder.Services.AddCors(options => options.AddPolicy("NextJS", policy =>
//{
//    if (builder.Environment.IsDevelopment())
//    {
//        policy.WithOrigins("http://localhost:3000")
//              .AllowAnyHeader()
//              .AllowAnyMethod();
//    }
//    else
//    {
//        policy.WithOrigins("http://localhost:3000")
//              .AllowAnyHeader()
//              .AllowAnyMethod();
//    }
//}));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred during user seeding.");
    }
}

app.UseHttpsRedirection();
app.UseCors("NextJS");
app.UseRouting();

app.UseMiddleware<JwtMiddleware>();

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
