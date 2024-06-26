using System.Reflection;
using Microsoft.EntityFrameworkCore;
using StartUp.Persistence.DbContexts;

namespace Api.Configurations;

public static partial class HostConfiguration
{
    // private static readonly ICollection<Assembly> Assemblies;
    // static HostConfiguration()
    // {
    //     Assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
    //     Assemblies.Add(Assembly.GetExecutingAssembly());
    // }
    private static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString")));
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
    private static WebApplication UseCors(this WebApplication app)
    {
        app.UseCors("AllowSpecificOrigin");

        return app;
    }
    private static WebApplication UseDevTools(this WebApplication app)
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
    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }
}