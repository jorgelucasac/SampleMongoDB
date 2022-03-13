﻿using Estudos.MongoDb.Application.Extensions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Estudos.MongoDb.Api.Extensions;

public static class Startup
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddVersionamento();
        services.AddSwaggerConfiguration();
        services.AddApplicationServices();
        services.AddAutoMapperExtension();

        return services;
    }

    public static WebApplication Configure(this WebApplication app)
    {
        var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        app.UseSwaggerConfiguration(apiVersionDescriptionProvider);

        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.MapControllers();
        return app;
    }
}