using Microsoft.AspNetCore.Mvc;

namespace Estudos.MongoDb.Api.Extensions.Version;

public static class VersionExtension
{
    public static void AddVersionamento(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            //assume a versão default quando não especificar a versão
            options.AssumeDefaultVersionWhenUnspecified = true;
            //versão default da API
            options.DefaultApiVersion = new ApiVersion(1, 0);
            //informa no header se a API está na ultima versão ou obsoleta
            options.ReportApiVersions = true;
        });

        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });
    }
}