using Serilog;
using Serilog.Events;
using Serilog.Exceptions;

namespace Estudos.MongoDb.Api.Extensions;

public static class SerilogExtension
{
    public static ILoggingBuilder AddSerilog(this ILoggingBuilder logging, IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .Enrich.WithCorrelationId()
            //.Filter.ByExcluding(z => z.MessageTemplate.Text.Contains("Business error"))
            .WriteTo.Async(a => a.Console())
            .CreateLogger();

        logging.AddSerilog(dispose: true);
        logging.AddConfiguration(configuration.GetSection("Logging"));

        //Log.Logger = new LoggerConfiguration()
        //    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
        //    .Enrich.FromLogContext()
        //    .Enrich.WithExceptionDetails()
        //    .Enrich.WithCorrelationId()
        //    .Enrich.WithProperty("ApplicationName", $"API MongoDb - {Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}")
        //    .Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore.StaticFiles"))
        //    .Filter.ByExcluding(z => z.MessageTemplate.Text.Contains("Business error"))
        //    .WriteTo.Async(wt => wt.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}"))
        //    .CreateLogger();

        return logging;
    }
}