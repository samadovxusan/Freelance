using System.Reflection;
using System.Text;
using Identity.Api.Middilware;
using Identity.Application.Common.Identity.Service;
using Identity.Domain.Common.Entities;
using Identity.Persistence.DataContext;
using Identity.Persistence.Repositories.Repositories;
using Identity.Persistence.Repositories.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Api.Configurations;

public static partial class  HostConfiguration
{
    private static readonly ICollection<Assembly> Assemblies;
    static HostConfiguration()
    {
        Assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
        Assemblies.Add(Assembly.GetExecutingAssembly());
    }
    private static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        var dbConnectionString = builder.Environment.IsProduction()
            ? Environment.GetEnvironmentVariable("DefaultConnectionString")
            : builder.Configuration.GetConnectionString("DefaultConnectionString");
        
        // Register db context
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(dbConnectionString);
            options.EnableSensitiveDataLogging();
        });
        builder.Services.AddIdentity<User, IdentityRole>(options =>
               {
                   options.Password.RequireLowercase = false;
                   options.Password.RequireUppercase = false;
                   options.Password.RequireNonAlphanumeric = false;
                   options.Password.RequireDigit = false;
               })
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<AppDbContext>();
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "http://localhost:5069/",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asfsafsasafjsafjksafksafsafsafsafasfasfafasfsafasfsafsafassaf"))
            };
        });
        
        
        
        return builder;
    }
    private static WebApplicationBuilder AddClientInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        

        return builder;
    }
    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        return builder;
    }

    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();
        
        return builder;
    }
    // private static WebApplicationBuilder AddMappers(this WebApplicationBuilder builder)
    // {
    //     builder.Services.AddAutoMapper(Assemblies);
    //     return builder;
    // }
    
   
    
    // private static WebApplicationBuilder AddValidators(this WebApplicationBuilder builder)
    // {
    //     builder.Services.Configure<ValidationSettings>(builder.Configuration.GetSection(nameof(ValidationSettings)));
    //
    //     builder.Services.AddValidatorsFromAssemblies(Assemblies).AddFluentValidationAutoValidation();
    //     
    //     return builder;
    // }
    private static WebApplicationBuilder AddMediator(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(conf => {conf.RegisterServicesFromAssemblies(Assemblies.ToArray());});
        
        return builder;
    }
    // private static async ValueTask<WebApplication> SeedDataAsync(this WebApplication app)
    // {
    //     var serviceScope = app.Services.CreateScope();
    //     await serviceScope.ServiceProvider.InitializeSeedAsync();
    //
    //     return app;
    // }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app.UseMiddleware<GlobalExceptionHandlingMiddlewareConventional>();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        
        return app;
    }
    private static WebApplication UseDevtools(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        
        return app;
    }
}