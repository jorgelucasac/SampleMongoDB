using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Reflection;

namespace Estudos.MongoDb.Api.Extensions;

public static class SwaggerExtension
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
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

    public static void UseSwaggerConfiguration(this IApplicationBuilder app,
        IApiVersionDescriptionProvider provider)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            //gera um end point para cada versao
            foreach (var description in provider.ApiVersionDescriptions)
                c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                    "Api MongoDb - " + description.GroupName.ToUpperInvariant());
        });
    }
}