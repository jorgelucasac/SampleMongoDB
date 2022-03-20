using Estudos.MongoDb.Api.Extensions.AutoMapper;
using Estudos.MongoDb.Api.Extensions.Middlewares;
using Estudos.MongoDb.Api.Extensions.Swagger;
using Estudos.MongoDb.Api.Extensions.Version;
using Estudos.MongoDb.Application.Extensions;
using Estudos.MongoDb.Infrastructure.Mongo.Extensions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Estudos.MongoDb.Api.Extensions;

public static class Startup
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddRouting(opt => opt.LowercaseUrls = true);
        services.AddEndpointsApiExplorer();

        services.AddVersionamento();
        services.AddSwaggerConfiguration();
        services.AddAutoMapperExtension();

        services.AddApplicationServices();
        services.AddMongoServices(configuration);

        return services;
    }

    public static WebApplication Configure(this WebApplication app)
    {
        var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        app.UseSwaggerConfiguration(apiVersionDescriptionProvider);

        app.UseMiddleware<ErrorHandlerMiddleware>();
        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.MapControllers();
        return app;
    }
}