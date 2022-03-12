using Estudos.MongoDb.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureServices(builder.Configuration);
builder.Logging.AddSerilog(builder.Configuration);

var app = builder.Build();
app.Configure();

await app.RunAsync();