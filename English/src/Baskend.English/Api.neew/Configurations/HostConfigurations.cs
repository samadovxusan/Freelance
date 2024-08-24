namespace Api.neew.Configurations;

public static partial class  HostConfigurations
{
    public static  ValueTask<WebApplicationBuilder> ConfigureAsnyc(this WebApplicationBuilder builder)
    {
        builder
            .AddPersistence()
            .AddDevTools()
            .AddExposers();
        return new ValueTask<WebApplicationBuilder>(builder);
    }
    
    public static async ValueTask<WebApplication> ConfigureAsnyc(this WebApplication  app)
    {
        app
            .UseDevtools()
            .UseExposers();
        return app; 
    }
    
} 