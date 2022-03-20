using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Estudos.MongoDb.Api.Extensions.Swagger;

public static class SwaggerExtension
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        //configurando o versionamento da documentação
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

        services.AddSwaggerGen(c =>
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

            if (File.Exists(xmlFile))
            {
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            }

            c.OperationFilter<SwaggerDefaultValues>();
        });
    }

    public static void UseSwaggerConfiguration(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            //gera um end point para cada versao
            foreach (var description in provider.ApiVersionDescriptions)
            {
                var notice = description.IsDeprecated ? "Esta versão está obsoleta" : string.Empty;

                c.SwaggerEndpoint(
                    $"/swagger/{description.GroupName}/swagger.json",
                    $"Api Restaurants - {description.GroupName.ToUpperInvariant()} {notice}");
            }
        });
    }
}