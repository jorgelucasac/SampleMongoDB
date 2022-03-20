using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Estudos.MongoDb.Api.Extensions.Swagger;

public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
    {
        _provider = provider;
    }

    public void Configure(SwaggerGenOptions options)
    {
        //add um doc para cada versão da api
        foreach (var description in _provider.ApiVersionDescriptions)
            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
    }

    //documentação com informação básica para cada versão
    private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    {
        var info = new OpenApiInfo
        {
            Title = "Restaurants API",
            Description = "Api de estudos MongoDb. <br> Permite realizar um crud de restaurantes e avalia-los",
            Contact = new OpenApiContact
            {
                Name = "Jorge Lucas",
                Email = "jorgelucasl91@gmail.com",
                Url = new Uri("https://www.linkedin.com/in/jorge-lucas/")
            },
            TermsOfService = new Uri("https://opensource.org/licenses/MIT"),
            License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") },
            Version = description.ApiVersion.ToString()
        };

        if (description.IsDeprecated) info.Description += " <b style='color: red;'>Esta versão está obsoleta!</b>";

        return info;
    }
}