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

        return services;
    }

    public static IApplicationBuilder Configure(this WebApplication app)
    {
        var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        app.UseSwaggerConfiguration(apiVersionDescriptionProvider);

        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.MapControllers();
        return app;
    }
}