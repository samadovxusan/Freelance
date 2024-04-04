using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence.DataContext;

namespace IdentityConfiguration.Configurations;

public static partial class  HostConfigurations
{
    private static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString")));
        return builder;
    }
   
    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();
        builder.Services.AddEndpointsApiExplorer();
        
        return builder;
    }

    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();
        
        return builder;
    }
    private static WebApplicationBuilder AddMappers(this WebApplicationBuilder builder)
    {
        return builder;
    }
    
    private static WebApplication UseDevtools(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        
        return app;
    }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        
        return app;
    }
}

