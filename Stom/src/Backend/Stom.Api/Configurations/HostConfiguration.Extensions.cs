using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stom.Persistence.DbContexts;

namespace Stom.Api.Configurations;

public static partial class HostConfiguration
{
    private static readonly ICollection<Assembly> Assemblies;

    static HostConfiguration()
    {
        Assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
        Assemblies.Add(Assembly.GetExecutingAssembly());
    }

    public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString")));
        return builder;
    }


    public static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder;
    }

    public static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();
        
        return builder;
    }
    
    // private static async ValueTask<WebApplication> MigrateDataBaseSchemasAsync(this WebApplication app)
    // {
    //     var serviceScopeFactory = app.Services.GetRequiredKeyedService<IServiceScopeFactory>(null);
    //     
    //     await serviceScopeFactory.MigrateAsync<AppDbContext>();
    //     
    //     return app;
    // }
    
    // private static async ValueTask<WebApplication> SeedDataAsync(this WebApplication app)
    // {
    //     var serviceScope = app.Services.CreateScope();
    //     await serviceScope.ServiceProvider.InitializeSeedAsync();
    //
    //     return app;
    // }
    
    /// <summary>
    /// Enables CORS middleware in the web application pipeline.
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    private static WebApplication UseCors(this WebApplication app)
    {
        app.UseCors("AllowSpecificOrigin");

        return app;
    }

    /// <summary>   
    /// Add Controller middleWhere
    /// </summary>
    /// <param name="app">Application host</param>
    /// <returns>Application host</returns>
    public static WebApplication UseDevTools(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
    
    /// <summary>
    /// Add Controller middleWhere
    /// </summary>
    /// <param name="app">Application host</param>
    /// <returns>Application host</returns>
    public static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }
}