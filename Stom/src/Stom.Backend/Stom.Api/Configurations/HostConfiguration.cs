namespace Stom.Api.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddPersistence()
            .AddDevTools()
            .AddExposers();

        return new ValueTask<WebApplicationBuilder>(builder);
    }

    public static async ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        // await app.MigrateDataBaseSchemasAsync();
        app.UseCors();
        app
            .UseDevTools()
            .UseExposers();
        return app;
    }
}