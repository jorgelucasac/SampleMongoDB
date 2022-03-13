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

        return logging;
    }
}