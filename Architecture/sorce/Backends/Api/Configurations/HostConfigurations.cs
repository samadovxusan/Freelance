namespace Api.Configurations;

public static partial class  HostConfigurations
{
    public static  ValueTask<WebApplicationBuilder> ConfigureAsnyc(this WebApplicationBuilder builder)
    {
        builder
            .AddPersistence()   
            .AddIdentityInfrastructure()
            .AddDevTools()
            .AddExposers();
        return new ValueTask<WebApplicationBuilder>(builder);
    }
    
    public static ValueTask<WebApplication> ConfigureAsnyc(this WebApplication  app)
    {
        app
            .UseDevtools()
            .UseExposers();
        return new ValueTask<WebApplication>(app);
    }
    
} 