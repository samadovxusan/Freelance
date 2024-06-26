﻿using Applaication.Common.Identity.Services;
using Infrastructure.Common.Identity.Services;
using Microsoft.EntityFrameworkCore;
using Persistence.DataContext;

namespace Api.Configurations;

public static partial class  HostConfigurations
{
    private static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
        return builder;
    }
    private static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserService, UserServices>();

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

    private static WebApplication UseDevtools(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        
        return app;
    }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();
        
        return app;
    }
}