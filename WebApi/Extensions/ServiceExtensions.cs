using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using SedisBackend.Core.Application;
using SedisBackend.Core.Application.Validators.LabTestValidators;
using SedisBackend.Core.Domain.DTO.Error;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Interfaces.Loggers;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Interfaces.Services.Identity;
using SedisBackend.Core.Domain.Interfaces.Services.Shared;
using SedisBackend.Core.Domain.Settings;
using SedisBackend.Infrastructure.Persistence;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories;
using SedisBackend.Infrastructure.Persistence.Services;
using SedisBackend.Infrastructure.Shared.Services;
using System.Text;

namespace WebApi.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) =>
    services.AddCors(options => options.AddPolicy("SedisPolicy", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        /*.WithOrigins("http://localhost:3000")*/
    }));

    public static void AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ApplicationAssemblyReference).Assembly);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyReference).Assembly));
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<CreateLabTestCommandValidator>();
    }

    public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        #region Context
        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<SedisContext>(options => options.UseInMemoryDatabase("Sedis"));
        }
        else
        {
            services.AddDbContext<SedisContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    m => m.MigrationsAssembly(typeof(PersistenceAssemblyReference).Assembly.FullName))
                .EnableSensitiveDataLogging(true);
            });
        }
        #endregion
        services.AddScoped<IAuthService, AuthenticationService>();
    }

    public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
        services.AddTransient<IEmailService, EmailService>();
        services.AddSingleton<ICardValidationService, CardValidationService>();
        services.AddSingleton<IChatGPTService, ChatGPTService>();
    }

    public static void ConfigureIdentity(this IServiceCollection services)
    {
        var builder = services.AddIdentity<User, IdentityRole<Guid>>(o =>
        {
            o.Password.RequireDigit = true;
            o.Password.RequireLowercase = false;
            o.Password.RequireUppercase = false;
            o.Password.RequireNonAlphanumeric = false;
            o.Password.RequiredLength = 10;
            o.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<SedisContext>()
        .AddDefaultTokenProviders();

        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/User";
            options.AccessDeniedPath = "/User/AccessDenied";
        });
    }

    public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("JWTSettings").Get<JWTSettings>();
        var jwtKey = configuration["JWTSettings:Key"];

        if (jwtSettings != null && jwtKey != null)
            services.AddSingleton(jwtSettings);
        else
            throw new Exception("JWTSettings not loaded.");

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = configuration["JWTSettings:Issuer"],
                ValidAudience = configuration["JWTSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
            };
            options.Events = new JwtBearerEvents()
            {
                OnAuthenticationFailed = c =>
                {
                    c.NoResult();
                    c.Response.StatusCode = 500;
                    c.Response.ContentType = "text/plain";
                    return c.Response.WriteAsync(c.Exception.ToString());
                },
                OnChallenge = c =>
                {
                    c.HandleResponse();
                    c.Response.StatusCode = 401;
                    c.Response.ContentType = "application/json";
                    var errors = new List<CustomError> { new CustomError { Code = "AUTH01", Description = "You are not authorized." } };
                    var result = JsonConvert.SerializeObject(new ServiceResult { Succeeded = true, Errors = errors });
                    return c.Response.WriteAsync(result);
                },
                OnForbidden = c =>
                {
                    c.Response.StatusCode = 403;
                    c.Response.ContentType = "application/json";
                    var errors = new List<CustomError> { new CustomError { Code = "AUTH02", Description = "You are not authorized to access this resource." } };
                    var result = JsonConvert.SerializeObject(new ServiceResult { Succeeded = true, Errors = errors });
                    return c.Response.WriteAsync(result);
                }
            };
        }).AddCookie(options =>
        {
            options.Cookie.HttpOnly = true;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        }); ;

        services.AddScoped<ITokenService, TokenService>();
    }

    public static void ConfigureIISIntegration(this IServiceCollection services) =>
    services.Configure<IISOptions>(options =>
    {
    });

    public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerManager, LoggerManager>();

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void AddSwaggerExtension(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(options =>
        {
            List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", searchOption: SearchOption.TopDirectoryOnly).ToList();
            xmlFiles.ForEach(xmlFile => options.IncludeXmlComments(xmlFile));

            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Sedis API",
                Description = "This API was designed for sedis services.",
                Contact = new OpenApiContact
                {
                    Name = "Sedis - Dominican Republic",
                    Email = "sedisinford@gob.do",
                    Url = new Uri("https://www.itla.edu.do"),
                }
            });

            options.EnableAnnotations();
            options.DescribeAllParametersInCamelCase();
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                Description = "Input your Bearer token in this format - Bearer {your token here}"
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id="Bearer"
                        },
                        Scheme = "Bearer",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    }, new List<string>()
                },
            });
        });
    }

    public static void ConfigureVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(config =>
        {
            config.ReportApiVersions = true;
            config.AssumeDefaultVersionWhenUnspecified = true;
            config.DefaultApiVersion = new ApiVersion(1, 0);
            config.ApiVersionReader = new HeaderApiVersionReader("api-version");
        });
    }
}
